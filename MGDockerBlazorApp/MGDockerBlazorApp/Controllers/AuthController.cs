using MGDockerBlazorApp.Database;
using MGDockerBlazorApp.Database.DatabaseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MGDockerBlazorApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly MGDatabaseContext _dbContext;
        private IConfiguration _config;

        public AuthController(MGDatabaseContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Login(string login)
        {
            var user = AuthenticateUser(login);
            IActionResult response = Unauthorized();
            var tokenString = GenerateJSONWebToken();
            response = Ok(new { token = tokenString });

            return response;
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private dynamic AuthenticateUser(string login)
        {
            dynamic user = null;

            if (login == "test")
            {
                user = new { Username = "Maciej", EmailAddress = "maciej.test@gmail.com" };
            }
            return user;
        }
    }
}
