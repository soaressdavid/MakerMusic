using MakerMusic.Api.Domain;

namespace MakerMusic.Api.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();

        Task<Student?> AddStudentAsync(Student student);

        Task<Student?> GetStudentByIdAsync(Guid id);

        Task<bool> UpdateStudentAsync(Guid id, Student student);

        Task<bool> DeleteStudentAsync(Guid id);

    }
}
