using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProesBack.Domain.Entities;
using ProesBack.Domain.Enums;
using ProesBack.Interfaces;
using ProesBack.ViewModels;

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
        public async Task<IActionResult> GetByLoginId(long loginId)
        {
            try
            {
                var user = _userViewModelService.GetUserByLoginId(loginId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId(long userId)
        {
            try
            {
                var user = _userViewModelService.GetByUserId(userId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Insert([FromBody]UserViewModel user)
        {
            try
            {
                if (user == null)
                    return BadRequest("User is empty");

                var newUser = await GetByUserId(user.Id);
                
                if (newUser != null)
                    return BadRequest("User already exists");

                _userViewModelService.InsertUser(user);

                _loginViewModelService.UpdateLogin(new Login
                {
                    Id = user.LoginId,
                    UserId = user.Id,
                });

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(UserViewModel user)
        {
            try
            {
                if (user == null)
                    return BadRequest("User is empty");

                if (GetByUserId(user.Id) == null)
                    return BadRequest("User not found");

                _userViewModelService.UpdateUser(user);
                return Ok(user);
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
        public async Task<IActionResult> SendPicture(IFormFile file, long userId)
        {
            try
            {
                if (file == null)
                    return BadRequest("File is empty");

                if (!(file.ContentType.Contains("image") || _userViewModelService.GetSupportedPictureTypes().Any(t => file.ContentType.Contains(t.ToString()))))
                    return BadRequest("File is not an upported image file");

                var user = _userViewModelService.GetByUserId(userId);
                if (user == null)
                    return BadRequest("User not found");

                var fileUpload = _userViewModelService.UploadPicture(userId,file);
                
                user.PictureUrl = _userViewModelService.GetLinkToPicture(userId);
                _userViewModelService.UpdateUser(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetPicture")]
        public async Task<IActionResult> GetPicture(long userId)
        {
            try
            {
                var user = _userViewModelService.GetByUserId(userId);
                if (user == null)
                    return BadRequest("User not found");

                var pictureUrl = _userViewModelService.GetLinkToPicture(userId);
                return Ok(pictureUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
