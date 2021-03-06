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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;

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
            return await this.context.Recipes.Include(r => r.Ingredients)
            .ThenInclude(r => r.Unit)
            .Include(r => r.Steps)
            .Include(r => r.Likes)
            .Include(r => r.Comments)
            .Include(r => r.User)
            .Include(r => r.Tags).ToListAsync();
        }


        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetUserRecipes(int id)
        {
            return await this.context.Recipes.Where(r => r.User.UserId == id)
            .Include(r => r.Ingredients)
            .ThenInclude(r => r.Unit)
            .Include(r => r.Steps)
            .Include(r => r.Likes)
            .Include(r => r.Comments)
            .Include(r => r.User)
            .Include(r => r.Tags)
            .ToListAsync();
        }

        [HttpGet("token")]
        [Authorize]
        public async Task<ActionResult<string>> GetToken()
        {
            var accessToken = await
            HttpContext.GetTokenAsync("access_token");

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(accessToken);
            var claims = token.Claims;
            var userName = claims.First(c => c.Type == "UserName").Value;
            return userName;
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateRecipe(RecipeDto recipeDto)
        {
            var user = this.context.Users.Find(recipeDto.User.UserId);
            var recipe = new Recipe
            {
                Title = recipeDto.Title,
                Description = recipeDto.Description,
                Persons = recipeDto.Persons,
                Image = recipeDto.Image,
                Ingredients = new List<Ingredient>(),
                Steps = recipeDto.Steps,
                Tags = new List<Tag>(),
                User = user
            };
            var tags = recipeDto.Tags;
            foreach (var tag in tags)
            {
                var exTag = this.context.Tags.Single(t => t.TagId == tag.TagId);
                recipe.Tags.Add(exTag);
            }
            var ingredients = recipeDto.Ingredients;
            foreach (var ingredient in ingredients)
            {
                ingredient.Unit = this.context.Units.Single(u => u.UnitId == ingredient.Unit.UnitId);
            }
            recipe.Ingredients = ingredients;


            this.context.Recipes.Add(recipe);
            await this.context.SaveChangesAsync();

            return recipe.RecipeId;
        }

        [HttpPost("image")]
        public async Task<ActionResult<ImageDto>> UploadFileAsync([FromForm] IFormFile recipeImage){
            Console.Write(recipeImage);
            var totalSize = recipeImage.Length;
            var fileBytes = new byte[recipeImage.Length];
            using (var fileStream = recipeImage.OpenReadStream()){
                var offset = 0;
                while(offset < recipeImage.Length)
                {
                    var chunkSize = totalSize - offset < 8192 ? (int) totalSize - offset : 8192;

                    offset += await fileStream.ReadAsync(fileBytes, offset, chunkSize);
                }
            }
            var randomString = Guid.NewGuid().ToString("n").Substring(0,8);
            var fileName = randomString+recipeImage.FileName;
            FileStream fs = new FileStream("uploads/"+fileName, FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(fileBytes);
            bw.Close();
            return new ImageDto(){
                Image = fileName
            };
        }

        [HttpPost("update")]
        public async Task<ActionResult<int>> Update(RecipeDto recipeDto)
        {

            var recipe = this.context.Recipes
            .Include(r => r.Tags)
            .Include(r => r.Steps)
            .Include(r => r.Ingredients)
            .SingleOrDefault(r => r.RecipeId == recipeDto.RecipeId);

            if (recipe != null)
            {
                foreach (var tag in recipe.Tags)

                    recipe.Tags.Remove(tag);

                foreach (var ingredient in recipe.Ingredients)
                    recipe.Ingredients.Remove(ingredient);

                foreach (var step in recipe.Steps)
                    recipe.Steps.Remove(step);
            }

            var tags = recipeDto.Tags;
            foreach (var tag in tags)
            {
                var exTag = this.context.Tags.Single(t => t.TagId == tag.TagId);
                recipe.Tags.Add(exTag);
            }

            var steps = recipeDto.Steps;
            foreach (var step in steps)
            {
                step.StepId = 0;
                recipe.Steps.Add(step);
            }

            foreach (var ingredient in recipeDto.Ingredients)
            {
                ingredient.IngredientId = 0;
                ingredient.Unit = this.context.Units.Single(u => u.UnitId == ingredient.Unit.UnitId);
                recipe.Ingredients.Add(ingredient);
            }

            recipe.RecipeId = recipeDto.RecipeId;
            recipe.Title = recipeDto.Title;
            recipe.Description = recipeDto.Description;
            recipe.Persons = recipeDto.Persons;
            recipe.Image = recipeDto.Image;

            this.context.Update(recipe);
            await this.context.SaveChangesAsync();

            return recipe.RecipeId;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> GetRecipe(int id)
        {
            var recipe = await this.context.Recipes
            .Include(r => r.Ingredients)
            .ThenInclude(r => r.Unit)
            .Include(r => r.Steps)
            .Include(r => r.Likes)
            .Include(r => r.Comments)
            .Include(r => r.User)
            .Include(r => r.Tags)
            .FirstOrDefaultAsync(r => r.RecipeId == id);

            Console.WriteLine(recipe);

            return new RecipeDto()
            {
                Title = recipe.Title,
                Description = recipe.Description,
                Image = recipe.Image,
                Steps = recipe.Steps,
                Ingredients = recipe.Ingredients,
                Likes = recipe.Likes,
                Tags = recipe.Tags,
                Comments = recipe.Comments,
                User = new UserDto()
                {
                    UserId = recipe.User.UserId,
                    Username = recipe.User.UserName,
                    UserRole = recipe.User.UserRole
                }
            };
        }

    }
}