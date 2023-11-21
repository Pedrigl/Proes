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

        [HttpGet("GetByLoginId")]
        public async Task<User> GetByLoginId(int loginId)
        {
            try
            {
                var user = _userViewModelService.GetUserByLoginId(loginId);
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("GetByUserId")]
        public async Task<User> GetByUserId(int userId)
        {
            try
            {
                var user = _userViewModelService.GetByUserId(userId);
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Insert([FromBody]User user)
        {
            try
            {
                if (user == null)
                    return BadRequest("User is empty");

                var newUser = await GetByUserId(user.Id);
                
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

                if (GetByUserId(user.Id) == null)
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
        public IActionResult Delete(int userId)
        {
            try
            {
                if (GetByUserId(userId) == null)
                    return BadRequest("User not found");

                _loginViewModelService.DeleteLogin(userId);
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

                var user = _userViewModelService.GetByUserId(int.Parse(User.Identity.Name));
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
