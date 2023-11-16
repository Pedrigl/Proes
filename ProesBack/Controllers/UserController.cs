using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProesBack.Domain.Entities;
using ProesBack.Interfaces;

namespace ProesBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<User> Get(int userId)
        {
            try
            {
                var user = _userViewModelService.GetUser(userId);
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(User user)
        {
            try
            {
                if (user == null)
                    return BadRequest("User is empty");

                var newUser = await Get(user.Id);
                
                if (newUser != null)
                    return BadRequest("User already exists");

                _userViewModelService.InsertUser(user);
                return Ok(user);
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

        [HttpPost("SendPicture")]
        public IActionResult SendPicture(IFormFile file)
        {
            try
            {
                if (file == null)
                    return BadRequest("File is empty");

                var user = _userViewModelService.GetUser(int.Parse(User.Identity.Name));
                user.PictureUrl = _userViewModelService.UploadPicture(file);
                _userViewModelService.UpdateUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
