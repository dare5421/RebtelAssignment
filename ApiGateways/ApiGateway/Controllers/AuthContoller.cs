using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiGateway.Controllers
{
    [Route("token")]
    [ApiController]
    public class AuthContoller : ControllerBase
    {
        /// <summary>
        /// Get valid JWT token
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [Route("auth")]
        public IActionResult Authenticate()
        {
            return Ok(GenerateToken());
        }
        private string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bleso%54#shenta#@147a"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>{
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString())
        };
            var token = new JwtSecurityToken("Dariush",
                "Dariush",
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
