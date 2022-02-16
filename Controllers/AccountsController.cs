using Castle.Core.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{   
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AccountsController(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest) 
        {
            AppUser user = _context.Users.Where(u => u.Login == loginRequest.Login).FirstOrDefault();
            string passwordHash = user.Password;
            string curHashedPassword = "";

            Claim[] userclaim = new[] {
                new Claim(ClaimTypes.Name, "aaa"),
                new Claim(ClaimTypes.Role, "user"),
                new Claim(ClaimTypes.Role, "Admin")
            };

            if (passwordHash != curHashedPassword)
            {
                return Unauthorized();
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost:44396",
                audience: "https://localhost:44396",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
             );

            user.RefreshToken = Guid.NewGuid().ToString();
            user.RefreshTokenExpirationDate = DateTime.Now.AddDays(1);
            _context.SaveChanges();

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = "asgdadsfgasgasvaneaw23452345"
            });
        }
    }
}
