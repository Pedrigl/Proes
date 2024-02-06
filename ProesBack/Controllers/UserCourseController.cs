using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProesBack.Domain.Models;
using ProesBack.Interfaces;
using ProesBack.ViewModels;

namespace ProesBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin, principal")]
    public class UserCourseController : ControllerBase
    {
        private readonly IUserCourseViewModelService _userCourseViewModelService;
        private readonly IUserViewModelService _userViewModelService;
        private readonly ICourseViewModelService _courseViewModelService;
        
        public UserCourseController(IUserCourseViewModelService userCourseViewModelService, IUserViewModelService userViewModelService, ICourseViewModelService courseViewModelService)
        {
            _userCourseViewModelService = userCourseViewModelService;
            _userViewModelService = userViewModelService;
            _courseViewModelService = courseViewModelService;
        }

        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId(long userId)
        {
            try
            {
                var userCourses = _userCourseViewModelService.GetUserCoursesByUserId(userId);
                return Ok(userCourses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]UserCourseViewModel userCourse)
        {
            if (userCourse == null)
                return BadRequest("UserCourse is empty");

            try
            {
                var userCourseValidity = _userCourseViewModelService.IsUserCourseValid(userCourse);
                if (userCourseValidity.IsValid == false)
                    return BadRequest(userCourseValidity.Message);

                var newUserCourse = _userCourseViewModelService.GetUserCourse(userCourse.Id);
                if (newUserCourse != null)
                    return BadRequest("UserCourse already exists");

                _userCourseViewModelService.CreateCourseForUser(userCourse);
                return Ok(userCourse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]UserCourseViewModel userCourse)
        {
            try
            {
                var userCourseValidity = _userCourseViewModelService.IsUserCourseValid(userCourse);
                if (userCourseValidity.IsValid == false)
                    return BadRequest(userCourseValidity.Message);

                var newUserCourse = await GetByUserId(userCourse.Id);
                
                if (newUserCourse == null)
                    return BadRequest("UserCourse does not exist");

                _userCourseViewModelService.UpdateCourseForUser( userCourse.Id,userCourse);
                return Ok(userCourse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                return BadRequest(ex.Message);
            }
        }
    }
}
