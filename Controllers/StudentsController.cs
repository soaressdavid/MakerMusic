using MakerMusic.Api.Domain;
using MakerMusic.Api.DTOs;
using MakerMusic.Api.Infrastructure;
using MakerMusic.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MakerMusic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<ResponseStudentDTO>> AddStudentsAsync(CreateStudentDTO createStudentDTO)
        {
            try
            {
                var student = new Student(createStudentDTO.Name, createStudentDTO.Email, createStudentDTO.Password);
                await _service.AddStudentAsync(student);
                var responseStudentDto = new ResponseStudentDTO(student.Id, student.Name, student.Email);
                return Ok(responseStudentDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseStudentDTO?>> GetStudentById(Guid id)
        {
            try
            {

                var student = await _service.GetStudentByIdAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                var studentResponse = new ResponseStudentDTO(id, student.Name, student.Email);
                return StatusCode(200, studentResponse);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseStudentDTO>> UpdateStudentAsync(Guid id, UpdateStudentDTO updateStudentDTO)
        {
            try
            {
                var existingStudent = await _service.GetStudentByIdAsync(id);
                if (existingStudent == null)
                {
                    return NotFound();
                }

                var student = new Student(updateStudentDTO.Name, updateStudentDTO.Email, "SenhaIgnorada");

                await _service.UpdateStudentAsync(id, student);

                var response = new ResponseStudentDTO
                (
                    id,
                    updateStudentDTO.Name,
                    updateStudentDTO.Email
                );

                return Ok(response);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudentAsync(Guid id)
        {
            try
            {
                var existingStudent = await _service.GetStudentByIdAsync(id);
                if (existingStudent == null) return NotFound();

                await _service.DeleteStudentAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
