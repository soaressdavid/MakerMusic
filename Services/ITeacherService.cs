using MakerMusic.Api.Domain;

namespace MakerMusic.Api.Services
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAllTeachers();

        Task<Teacher?> AddTeacherAsync(Teacher teacher);

        Task<Teacher?> GetTeacherById(Guid id);

        Task<bool> UpdateTeacherAsync(Guid id, Teacher teacher);

        Task<bool> DeleteTeacherAsync(Guid id);
    }
}
