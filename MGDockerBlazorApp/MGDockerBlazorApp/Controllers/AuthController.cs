using MGDockerBlazorApp.Client.Models;
using MGDockerBlazorApp.Database;
using MGDockerBlazorApp.Database.DatabaseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MGDockerBlazorApp.Controllers
{
    [ApiController]
    [IgnoreAntiforgeryToken]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly MGDatabaseContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private IConfiguration _config;

        public AuthController(MGDatabaseContext dbContext, IConfiguration config, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _config = config;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var authenticated = await AuthenticateUser(userLoginDto.Email, userLoginDto.Password);
            IActionResult response = Unauthorized();

            if (authenticated) 
            {
                var tokenString = GenerateJSONWebToken();
                response = Ok(new { token = tokenString });
            }

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

        private async Task<bool> AuthenticateUser(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var passwordCorrect = await _userManager.CheckPasswordAsync(user, password);

            return passwordCorrect;
        }
    }
}
