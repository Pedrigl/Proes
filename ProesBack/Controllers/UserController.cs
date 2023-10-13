using Microsoft.AspNetCore.Mvc;
using ProesBack.Domain.Entities;
using ProesBack.Interfaces;

namespace ProesBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoginViewModelService _loginViewModelService;
        private readonly IUserViewModelService _userViewModelService;

        public UserController(ILoginViewModelService loginViewModelService, IUserViewModelService userViewModelService)
        {
            _loginViewModelService = loginViewModelService;
            _userViewModelService = userViewModelService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<dynamic>> Get(int loginId)
        {
            try
            {
                var user = _loginViewModelService.GetLogin(loginId);
                return user;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }

        [HttpPost("Insert")]
        public IActionResult Insert(User user)
        {
            try
            {
                if (user == null)
                    return BadRequest("User is empty");

                if (Get(user.loginId).Result == null)
                    return BadRequest("User already exists");

                _userViewModelService.InsertUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(User user)
        {
            try
            {
                if (user == null)
                    return BadRequest("User is empty");

                if (Get(user.loginId) == null)
                    return BadRequest("User not found");

                _userViewModelService.UpdateUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int loginId)
        {
            try
            {
                if (Get(loginId) == null)
                    return BadRequest("User not found");

                _loginViewModelService.DeleteLogin(loginId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
