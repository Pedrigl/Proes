using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProesBack.Domain.Entities;
using ProesBack.Interfaces;
using ProesBack.ViewModels;

namespace ProesBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin, principal")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseViewModelService _courseViewModelService;
        

        public CourseController(ICourseViewModelService courseViewModelService)
        {
            _courseViewModelService = courseViewModelService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var courses = _courseViewModelService.GetCourses();
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var course = _courseViewModelService.GetCourse(id);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Insert([FromBody]CourseViewModel course)
        {
            try
            {
                if (course == null)
                    return BadRequest("Course is empty");

                var newCourse = await GetById(course.Id);

                if (newCourse != null)
                    return BadRequest("Course already exists");

                _courseViewModelService.CreateCourse(course);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]CourseViewModel course)
        {
            try
            {
                if (course == null)
                    return BadRequest("Course is empty");

                var newCourse = await GetById(course.Id);

                if (newCourse == null)
                    return BadRequest("Course does not exist");

                _courseViewModelService.UpdateCourse(course.Id,course);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var course = await GetById(id);

                if (course == null)
                    return BadRequest("Course does not exist");

                _courseViewModelService.DeleteCourse(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
