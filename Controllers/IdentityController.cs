using EntregaFinal.Services;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace TestAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(IdentityController));
        private const string SecretKey = "94e6dcc6d13ef93da7195a0e391b79a350eb44e6f1842087f5137ef1472f17a7";
        private const string Issuer = "http://localhost:5120";
        private const string Audience = "http://localhost:5120";

        private static TimeSpan TokenLifetime = TimeSpan.FromHours(1);

        [HttpPost(Name = "Login")]
        public ActionResult GenerateToken(LoginRequest request)
        {
            log.Info("Intento de login");
            if (!CheckUserAndPass())
            {
                log.Info("No se posee autorización");
                return Unauthorized();
            }

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var SecretToken = new JwtSecurityToken(
              Issuer,
              Audience,
              null,
              expires: DateTime.Now.Add(TokenLifetime),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(SecretToken);
            log.Info("token generado con éxito");
            return Ok(token);
        }
        
        private bool CheckUserAndPass()
        {
            return true;
        }
    }
}
