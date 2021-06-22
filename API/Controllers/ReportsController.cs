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
    public class ReportsController : ControllerBase
    {
        private readonly DataContext context;
        public ReportsController(DataContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportDto>>> GetReports()
        {
            var reports = await this.context.Reports.
            Include(r => r.ReportedUser)
            .Include(r => r.ReportingUser)
            .ToListAsync();
            var reportDtos = new List<ReportDto>();
            foreach(var report in reports){
                var dto = new ReportDto(){
                    TargetId = report.TargetId,
                    TargetTopic = report.TargetTopic,
                    ReportedUser = report.ReportedUser.UserId,
                    ReportedUserName = report.ReportedUser.UserName,
                    ReportedUserPenalty = report.ReportedUser.PenaltyPoints,
                    ReportingUser = report.ReportingUser.UserId,
                    ReportingUserName = report.ReportingUser.UserName,
                    ReportingUserPenalty = report.ReportingUser.PenaltyPoints
                };
                reportDtos.Add(dto);
            }
            return reportDtos;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Report>> CreateComment(IncReportDto reportDto)
        {
                        var accessToken = await
            HttpContext.GetTokenAsync("access_token");

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(accessToken);
            var claims = token.Claims;
            var userId = claims.First(c => c.Type =="UserId").Value;
            var report = new Report
            {
                ReportingUser = await this.context.Users.FindAsync(Convert.ToInt32(userId)),
                ReportedUser = await this.context.Users.FindAsync(reportDto.ReportedUser),
                TargetId = reportDto.TargetId,
                TargetTopic = reportDto.TargetTopic                
            };
            this.context.Reports.Add(report);
            await this.context.SaveChangesAsync();

            return report;
        }
    }
}