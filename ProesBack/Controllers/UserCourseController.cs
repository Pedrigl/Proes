using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProesBack.Interfaces;
using ProesBack.ViewModels;

namespace ProesBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCourseController : ControllerBase
    {
        private readonly IUserCourseViewModelService _userCourseViewModelService;

        public UserCourseController(IUserCourseViewModelService userCourseViewModelService)
        {
            _userCourseViewModelService = userCourseViewModelService;
        }

        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId(long userId)
        {
            try
            {
                var userCourses = _userCourseViewModelService.GetUserCourse(userId);
                return Ok(userCourses);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]UserCourseViewModel userCourse)
        {
            try
            {
                if (userCourse == null)
                    return BadRequest("UserCourse is empty");

                var newUserCourse = await GetByUserId(userCourse.Id);
                
                if (newUserCourse != null)
                    return BadRequest("UserCourse already exists");

                _userCourseViewModelService.CreateCourseForUser(userCourse);
                return Ok(userCourse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]UserCourseViewModel userCourse)
        {
            try
            {
                if (userCourse == null)
                    return BadRequest("UserCourse is empty");

                var newUserCourse = await GetByUserId(userCourse.Id);
                
                if (newUserCourse == null)
                    return BadRequest("UserCourse does not exist");

                _userCourseViewModelService.UpdateCourseForUser( userCourse.Id,userCourse);
                return Ok(userCourse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var userCourse = await GetByUserId(id);
                
                if (userCourse == null)
                    return BadRequest("UserCourse does not exist");

                _userCourseViewModelService.DeleteCourseForUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
