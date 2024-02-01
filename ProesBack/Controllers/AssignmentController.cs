using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProesBack.Interfaces;
using ProesBack.ViewModels;

namespace ProesBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentViewModelService _assignmentViewModelService;

        public AssignmentController(IAssignmentViewModelService assignmentViewModelService)
        {
            _assignmentViewModelService = assignmentViewModelService;
        }

        [HttpGet("GetByCourseId")]
        public async Task<IActionResult> GetByCourseId(long courseId)
        {
            try
            {
                var assignment = _assignmentViewModelService.GetAssignmentsByCourseId(courseId);
                return Ok(assignment);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetByAssignmentId")]
        public async Task<AssignmentViewModel> GetByAssignmentId(long assignmentId)
        {
            try
            {
                var assignment = _assignmentViewModelService.GetAssignmentById(assignmentId);
                return assignment;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Insert([FromBody]AssignmentViewModel assignment)
        {
            try
            {
                if (assignment == null)
                    return BadRequest("Assignment is empty");

                var newAssignment = await GetByAssignmentId(assignment.Id);
                
                if (newAssignment != null)
                    return BadRequest("Assignment already exists");

                _assignmentViewModelService.CreateAssignment(assignment);
                return Ok(assignment);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody]AssignmentViewModel assignment)
        {
            try
            {
                if (assignment == null)
                    return BadRequest("Assignment is empty");

                var newAssignment = await GetByAssignmentId(assignment.Id);
                
                if (newAssignment == null)
                    return BadRequest("Assignment does not exist");

                _assignmentViewModelService.UpdateAssignment(assignment);
                return Ok(assignment);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long assignmentId)
        {
            try
            {
                var assignment = await GetByAssignmentId(assignmentId);
                
                if (assignment == null)
                    return BadRequest("Assignment does not exist");

                _assignmentViewModelService.DeleteAssignment(assignmentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
