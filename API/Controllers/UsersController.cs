using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext context;
        public UsersController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id){
            var user = this.context.Users.Find(id);
            return user;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers(){
            var users = this.context.Users.ToList();

            return users;
        }
    }
}