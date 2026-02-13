using MakerMusic.Api.Domain;
using MakerMusic.Api.Repositories;

namespace MakerMusic.Api.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _repository.GetAllCourses();
        }

        public async Task<Course?> GetCourseById(Guid id)
        {
            return await _repository.GetCourseById(id);
        }

        public async Task<Course?> AddCourseAsync(Course course)
        {
            return await _repository.AddCourseAsync(course);
        }

        public async Task<bool> UpdateCourseAsync(Guid id, Course course)
        {
            return await _repository.UpdateCourseAsync(id, course);
        }

        public async Task<bool> DeleteCourseAsync(Guid id)
        {
            return await _repository.DeleteCourseAsync(id);
        }
    }
}
