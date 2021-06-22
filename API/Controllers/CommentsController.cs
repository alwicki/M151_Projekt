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
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly DataContext context;
        public CommentsController(DataContext context)
        {
            this.context = context;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Comment>> CreateComment(CommentDto commentDto)
        {
            var accessToken = await
HttpContext.GetTokenAsync("access_token");

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(accessToken);
            var claims = token.Claims;
            var userName = claims.First(c => c.Type == "UserName").Value;
            var userId = claims.First(c => c.Type == "UserId").Value;
            var comment = new Comment
            {
                Description = commentDto.Description,
                RecipeId = commentDto.RecipeId,
                Date = DateTime.Now,
                UserId = Convert.ToInt32(userId),
                UserName = userName

            };
            this.context.Comments.Add(comment);
            await this.context.SaveChangesAsync();

            return comment;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetComment(int id)
        {
            var comment = await this.context.Comments
                        .FirstOrDefaultAsync(c => c.CommentId == id);
            return new CommentDto()
            {
                Description = comment.Description
            };
        }
    }
}