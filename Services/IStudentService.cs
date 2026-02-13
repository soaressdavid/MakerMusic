using MakerMusic.Api.Domain;
using MakerMusic.Api.DTOs;

namespace MakerMusic.Api.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllAsync();

        Task<Student?> AddStudentAsync(Student student);

        Task<Student?> GetStudentByIdAsync(Guid id);

        Task<bool> UpdateStudentAsync(Guid id, Student student);

        Task<bool> DeleteStudentAsync(Guid id);
    }
}
