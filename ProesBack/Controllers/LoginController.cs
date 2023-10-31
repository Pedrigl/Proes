using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProesBack.Domain.Entities;
using ProesBack.Infrastructure.Data.Common;
using ProesBack.Interfaces;
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

        [HttpPost("Login")]
        public async Task<ActionResult<dynamic>> Login(Login login)
        {
            try
            {
                var user = _loginViewModelService.GetLogin(login.Username, login.Password) ;
                var token = _loginViewModelService.Authenticate(user);

                _loginViewModelService.UpdateLogin(new Login{
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Token = token,
                    TokenExpiration = 3,
                    UserType = user.UserType
                });

                
                if (token == null)
                    return BadRequest("Username or password is incorrect");

                user.Password = "";
                return user;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }

        [HttpPost("Register")]
        public IActionResult Register(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return BadRequest("Username or password is empty");

                var user = _loginViewModelService.GetLogin(username, password);
                if(user.Username.IsNullOrEmpty())
                {
                    _loginViewModelService.InsertLogin(new Domain.Entities.Login
                    {
                        Username = username,
                        Password = password,
                        TokenExpiration = 3,
                        Token = Encoding.ASCII.GetBytes(Settings.GetKey()).ToString()
                });

                    return CreatedAtAction(null, null);
                }
            }
            catch (Exception ex)
            {
                StatusCode(500, ex.Message);
                throw;
            }
            return BadRequest(username + " already exists");
            
        }
    }
}
