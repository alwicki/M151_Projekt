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
    public class TagsController : ControllerBase
    {
        private readonly DataContext context;
        public TagsController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetRecipes()
        {
            return await this.context.Tags.ToListAsync();
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateTag(TagDto tagDto)
        {
            var tag = new Tag
            {
                Title = tagDto.Title,
            };
            this.context.Tags.Add(tag);
            await this.context.SaveChangesAsync();

            return tag.Id;
        }

    }
}