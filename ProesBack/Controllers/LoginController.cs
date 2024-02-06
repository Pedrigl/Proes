using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProesBack.Domain.Entities;
using ProesBack.Infrastructure.Data.Common;
using ProesBack.Interfaces;
using ProesBack.ViewModels;
using System.Text;

namespace ProesBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginViewModelService _loginViewModelService;

        public LoginController(ILoginViewModelService loginViewModelService)
        {
            _loginViewModelService = loginViewModelService;
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                var user = _loginViewModelService.GetLogin(username, password);
                if (user == null)
                    return BadRequest("Username or password is incorrect");

                var token = _loginViewModelService.Authenticate(user);

                _loginViewModelService.UpdateLogin(new Login{
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Token = token,
                    TokenExpiration = DateTime.Now.AddMinutes(30),
                    UserType = user.UserType
                });

                
                if (token == null)
                    return BadRequest("Failed to authenticate");

                return Ok(_loginViewModelService.GetLogin(user.Id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> Refresh([FromBody]LoginViewModel login)
        {
            try
            {
                var refreshToken = _loginViewModelService.RefreshJSONWebToken(login);
                return Ok(refreshToken);
            }

            catch (SecurityTokenException ex)
            {
                return BadRequest("Invalid token");
            }
            
        }

        [Authorize(Roles = "admin, principal")]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Login login)
        {
            try
            {
                if (string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
                    return BadRequest("Username or password is empty");

                var user = _loginViewModelService.GetLogin(login.Username, login.Password);
                if(user ==null)
                {
                    _loginViewModelService.InsertLogin(new Login
                    {
                        Username = login.Username,
                        Password = login.Password,
                        UserType = login.UserType
                });

                    return StatusCode(StatusCodes.Status201Created);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            return BadRequest(login.Username+ " already exists");
            
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var login = _loginViewModelService.GetLogin(id);
                if (login == null)
                    return BadRequest("Login not found");

                _loginViewModelService.DeleteLogin(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
