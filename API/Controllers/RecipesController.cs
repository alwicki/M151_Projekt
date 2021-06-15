using API.Data;
using API.Entities;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Text;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly DataContext context;
        public RecipesController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            return await this.context.Recipes.ToListAsync();
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetUserRecipes(int id)
        {
            return await this.context.Recipes.Where(r => r.User.UserId == id).Include(r => r.Tags).ToListAsync();
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateRecipe(RecipeDto recipeDto)
        {
            var test = recipeDto;
            var user = this.context.Users.Find(recipeDto.User.UserId);
            var recipe = new Recipe
            {
                Title = recipeDto.Title,
                Description = recipeDto.Description,
                Persons = recipeDto.Persons,
                Ingredients = new List<Ingredient>(),
                Steps = recipeDto.Steps,
                Tags = new List<Tag>(),
                User = user
            };
            var tags = recipeDto.Tags;
            foreach(var tag in tags ){
                var exTag = this.context.Tags.Single(t=> t.TagId == tag.TagId);
                recipe.Tags.Add(exTag);
            }
            var ingredients = recipeDto.Ingredients;
            foreach(var ingredient in ingredients){
                ingredient.Unit = this.context.Units.Single(u => u.UnitId == ingredient.Unit.UnitId);
            }
            recipe.Ingredients = ingredients;


            this.context.Recipes.Add(recipe);
            await this.context.SaveChangesAsync();

            return recipe.RecipeId;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> GetRecipe(int id)
        {
            //var user = this.context.Recipes.Include(u=>u.User).First(r => r.Id == id).User;
            
            var recipe = await this.context.Recipes
            .Include(r => r.Ingredients)
            .ThenInclude( r => r.Unit)
            .Include(r => r.Steps)
            .Include(r => r.Likes)
            .Include(r => r.Comments)
            .Include(r => r.User)
            .Include(r => r.Tags)
            .FirstOrDefaultAsync(r => r.RecipeId == id);

            Console.WriteLine(recipe);

            return new RecipeDto(){
                Title = recipe.Title,
                Description = recipe.Description,
                Steps = recipe.Steps,
                Ingredients = recipe.Ingredients,
                Likes = recipe.Likes,
                Tags = recipe.Tags,
                Comments = recipe.Comments,
                User = new UserDto(){
                    UserId = recipe.User.UserId,
                    Username = recipe.User.UserName,
                    UserRole = recipe.User.UserRole
                }
            };
        }

    }
}