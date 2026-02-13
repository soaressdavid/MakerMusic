using MakerMusic.Api.Domain;
using MakerMusic.Api.Infrastructure;

namespace MakerMusic.Api.Repositories
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllTeachers();
        Task<Teacher?> AddTeacherAsync(Teacher teacher);
        Task<Teacher?> GetTeacherById(Guid id);
        Task<bool> UpdateTeacherAsync(Guid id, Teacher teacher);
        Task<bool> DeleteTeacherAsync(Guid id);
    }
}
