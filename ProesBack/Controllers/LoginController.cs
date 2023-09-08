using Microsoft.AspNetCore.Mvc;
using ProesBack.Interfaces;


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
        public async Task<ActionResult<dynamic>> Login(string username, string password)
        {
            try
            {
                var user = _loginViewModelService.Get(username, password);
                var token = _loginViewModelService.GenerateToken(new Domain.Entities.Login
                {
                    Username = username,
                    Password = password
                });

                if (token == null)
                    return BadRequest("Username or password is incorrect");

                return new
                {
                    user = user,
                    token = token
                };
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
                var user = _loginViewModelService.Get(username, password);
                if(user == null)
                {
                    _loginViewModelService.Insert(new Domain.Entities.Login
                    {
                        Username = username,
                        Password = password
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
