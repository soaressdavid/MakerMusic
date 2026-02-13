using MakerMusic.Api.Domain;

namespace MakerMusic.Api.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCourses();
        Task<Course?> GetCourseById(Guid id);
        Task<Course?> AddCourseAsync(Course course);
        Task<bool> UpdateCourseAsync(Guid id, Course course);
        Task<bool> DeleteCourseAsync(Guid id);
    }
}
