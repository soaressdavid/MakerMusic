using MakerMusic.Api.Domain;
using MakerMusic.Api.Repositories;

namespace MakerMusic.Api.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;
        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Teacher>> GetAllTeachers()
        {
            return await _repository.GetAllTeachers();
        }

        public async Task<Teacher?> AddTeacherAsync(Teacher teacher)
        {
            return await _repository.AddTeacherAsync(teacher);
        }

        public async Task<Teacher?> GetTeacherById(Guid id)
        {
            return await _repository.GetTeacherById(id);
        }

        public async Task<bool> UpdateTeacherAsync(Guid id, Teacher teacher)
        {
            return await _repository.UpdateTeacherAsync(id, teacher);
        }

        public async Task<bool> DeleteTeacherAsync(Guid id)
        {
            return await _repository.DeleteTeacherAsync(id);
        }
    }
}
