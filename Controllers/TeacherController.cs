using MakerMusic.Api.Domain;
using MakerMusic.Api.DTOs;
using MakerMusic.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MakerMusic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;
        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Teacher?>>> GetAllTeachers()
        {
            return StatusCode(200, await _service.GetAllTeachers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseTeacherDTO?>> GetTeacherById(Guid id)
        {
            try
            {
                var teacher = await _service.GetTeacherById(id);
                if (teacher == null) return StatusCode(404);

                var teacherResponse = new ResponseTeacherDTO(id, teacher.Name, teacher.Email, teacher.Bio);
                return StatusCode(200, teacherResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseTeacherDTO>> AddTeacherAsync(CreateTeacherDTO teacherDTO)
        {
            try
            {
                var teacher = new Teacher(teacherDTO.Name, teacherDTO.Email, teacherDTO.Bio);
                await _service.AddTeacherAsync(teacher);
                var responseDTO = new ResponseTeacherDTO(teacher.Id, teacher.Name, teacher.Email, teacher.Bio);
                return StatusCode(201, responseDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseTeacherDTO>> UpdateTeacherAsync(Guid id, UpdateTeacherDTO updateTeacherDTO)
        {
            try
            {
                var existingTeacher = await _service.GetTeacherById(id);
                if (existingTeacher == null) return StatusCode(404);

                var teacher = new Teacher(updateTeacherDTO.Name, updateTeacherDTO.Email, updateTeacherDTO.Bio);

                await _service.UpdateTeacherAsync(id, teacher);

                var responseTeacher = new ResponseTeacherDTO(id, teacher.Name, teacher.Email, teacher.Bio);
                return StatusCode(200, responseTeacher);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacherAsync(Guid id)
        {
            try
            {
                var existingTeacher = await _service.GetTeacherById(id);
                if (existingTeacher == null) return StatusCode(404);

                await _service.DeleteTeacherAsync(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
