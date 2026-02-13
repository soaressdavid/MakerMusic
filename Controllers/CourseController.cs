using MakerMusic.Api.Domain;
using MakerMusic.Api.DTOs;
using MakerMusic.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MakerMusic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;
        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Course>> GetAllCourses()
        {
            return await _service.GetAllCourses();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseCourseDTO?>> GetCourseById(Guid id)
        {
            try
            {
                var course = await _service.GetCourseById(id);
                if (course is null) return StatusCode(404);

                var courseResponse = new ResponseCourseDTO(id, course.Title, course.Description, course.Price, course.TeacherId);
                return StatusCode(200, courseResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseCourseDTO?>> AddCourseAsync(CreateCourseDTO createCourseDTO)
        {
            try
            {
                var course = new Course(createCourseDTO.Title, createCourseDTO.Description, createCourseDTO.Price, createCourseDTO.TeacherId);
                await _service.AddCourseAsync(course);
                var response = new ResponseCourseDTO(course.Id, course.Title, course.Description, course.Price, course.TeacherId);
                return StatusCode(201, response);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseCourseDTO>> UpdateCourseAsync(Guid id, UpdateCourseDTO updateCourseDTO)
        {
            try
            {
                var existingCourse = await _service.GetCourseById(id);
                if (existingCourse is null) return StatusCode(404);

                var course = new Course(updateCourseDTO.Title, updateCourseDTO.Description, updateCourseDTO.Price, existingCourse.TeacherId);
                await _service.UpdateCourseAsync(id, course);

                var response = new ResponseCourseDTO(id, course.Title, course.Description, course.Price, course.TeacherId);
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourseAsync(Guid id)
        {
            try
            {
                var existingCourse = await _service.GetCourseById(id);
                if (existingCourse is null) return StatusCode(404);

                await _service.DeleteCourseAsync(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
