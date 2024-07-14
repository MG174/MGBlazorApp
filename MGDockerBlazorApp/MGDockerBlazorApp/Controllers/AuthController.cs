using MediatR;
using MGDockerBlazorApp.Application.Features.Authentication.Commands;
using MGDockerBlazorApp.ClientModels.Models.Authentication;
using MGDockerBlazorApp.Database;
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
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly MGDatabaseContext _dbContext;
        private IConfiguration _config;
        private readonly IMediator _mediator;

        public AuthController(MGDatabaseContext dbContext, IConfiguration config, IMediator mediator)
        {
            _dbContext = dbContext;
            _config = config;
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<LoginUserResponse> Login(UserLogin userLogin)
        {
            var response = await _mediator.Send(new LoginUserRequest(userLogin.Email, userLogin.Password));
            return response;
        }

        [HttpPost]
        public async Task<ChangeUserPasswordResponse> ChangePassword(UserChangePassword userChangePassword)
        {
            var response = await _mediator.Send(new ChangeUserPasswordRequest(userChangePassword.Email, userChangePassword.PreviousPassword, userChangePassword.NewPassword));
            return response;
        }

        //private string GenerateJSONWebToken()
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //      _config["Jwt:Issuer"],
        //      null,
        //      expires: DateTime.Now.AddMinutes(120),
        //      signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        //private async Task<bool> AuthenticateUser(string email, string password)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);
        //    var passwordCorrect = await _userManager.CheckPasswordAsync(user, password);

        //    return passwordCorrect;
        //}
    }
}
