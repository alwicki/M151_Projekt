using API.Data;
using API.Entities;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Text;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet] public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes(){
        return await this.context.Recipes.ToListAsync();
        }

        [HttpPost("create")]
        public async Task<ActionResult<Recipe>> CreateRecipe(Recipe recipe)
        {
            this.context.Recipes.Add(recipe);
            await this.context.SaveChangesAsync();
            
            return await this.context.Recipes.FindAsync(1);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id){
            return await this.context.Recipes.Include(r => r.Steps).FirstOrDefaultAsync(r => r.Id == id);
        }

    }
}