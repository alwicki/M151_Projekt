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
    public class UnitsController : ControllerBase
    {
        private readonly DataContext context;
        public UnitsController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetUnits()
        {
            return await this.context.Units.ToListAsync();
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateUnit(UnitDto unitDto)
        {
            var unit = new Unit
            {
                Title = unitDto.Title,
            };
            this.context.Units.Add(unit);
            await this.context.SaveChangesAsync();

            return unit.UnitId;
        }

    }
}