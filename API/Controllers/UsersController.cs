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
    public class UsersController : ControllerBase
    {
        private readonly DataContext context;

        private readonly ITokenService tokenservice;
        public UsersController(DataContext context, ITokenService tokenService)
        {
            this.tokenservice = tokenService;
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(){
            return await this.context.Users.ToListAsync();
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id){
            User user = await this.context.Users.FindAsync(id);
            return new UserDto{
                UserId = user.UserId,
                Username = user.UserName,
                UserRole = user.UserRole
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username already exists");

            using var hmac = new HMACSHA512();

            var user = new User{
                UserName = registerDto.Username.ToLower(),
                UserRole = 0,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();
            
            return new UserDto{
                Username = user.UserName,
                UserRole = user.UserRole,
                Token = this.tokenservice.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await this.context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);
            
            if(user == null) return Unauthorized("Invalid username or password");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid username or password");
            }

         
            return new UserDto{
                UserId = user.UserId,
                Username = user.UserName,
                UserRole = user.UserRole,
                Token = this.tokenservice.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username){
            return await this.context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}