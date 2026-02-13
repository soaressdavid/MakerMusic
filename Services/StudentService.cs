using MakerMusic.Api.Domain;
using MakerMusic.Api.Repositories;

namespace MakerMusic.Api.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Student?> AddStudentAsync(Student student)
        {
            return await _repository.AddStudentAsync(student);
        }

        public async Task<Student?> GetStudentByIdAsync(Guid id)
        {
            return await _repository.GetStudentByIdAsync(id);
        }

        public async Task<bool> UpdateStudentAsync(Guid id, Student student)
        {
            return await _repository.UpdateStudentAsync(id, student);
        }

        public async Task<bool> DeleteStudentAsync(Guid id)
        {
            return await _repository.DeleteStudentAsync(id);
        }
    }
}
