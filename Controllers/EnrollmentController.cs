using MakerMusic.Api.Domain;
using MakerMusic.Api.DTOs;
using MakerMusic.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MakerMusic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _service;

        public EnrollmentController(IEnrollmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseEnrollmentDTO?>> CreateEnrollmentAsync([FromBody] CreateEnrollmentDTO createEnrollmentDTO)
        {
            try
            {
                var result = await _service.CreateEnrollmentAsync(createEnrollmentDTO.StudentId, createEnrollmentDTO.CourseId);
                if (result is null) return StatusCode(404);

                var responseStudentDTO = new ResponseStudentDTO(
                    result.Student.Id,
                    result.Student.Name,
                    result.Student.Email
                );

                var responseCourseDTO = new ResponseCourseDTO(
                    result.Course.Id,
                    result.Course.Title,
                    result.Course.Description,
                    result.Course.Price,
                    result.Course.TeacherId
                );

                var responseEnrollment = new ResponseEnrollmentDTO(result.Id, result.StudentId, result.CourseId, result.Price, result.EnrollmentDate, responseStudentDTO, responseCourseDTO);
                return CreatedAtAction(nameof(GetEnrollments), new { id = responseEnrollment.Id }, responseEnrollment);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseEnrollmentDTO>>> GetEnrollments()
        {
            try
            {
                var responses = await _service.GetEnrollmentsAsync();
                return Ok(responses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> CancelEnrollmentAsync(Guid id)
        {
            try
            {
                var success = await _service.CancelEnrollmentAsync(id);
                if (!success) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
