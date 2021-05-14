using API.Data;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet] public ActionResult GetRecipes(){
        return new JsonResult("Hello, this is the API speaking, there are no recipes");
        }

    }
}