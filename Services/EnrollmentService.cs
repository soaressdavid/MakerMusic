using MakerMusic.Api.Domain;
using MakerMusic.Api.Repositories;

namespace MakerMusic.Api.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _repository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        public EnrollmentService(IEnrollmentRepository repository, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _repository = repository;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
        }

        public async Task<Enrollment?> CreateEnrollmentAsync(Guid studentId, Guid courseId)
        {
            var student = await _studentRepository.GetStudentByIdAsync(studentId);
            var course = await _courseRepository.GetCourseById(courseId);

            if (student is null || course is null) return null;

            var exists = await _repository.VerifyEnrollmentAsync(student.Id, course.Id);
            if (exists) throw new InvalidOperationException("O aluno já está matriculado neste curso.");

            var enrollment = new Enrollment(student.Id, course.Id, course.Price);
            await _repository.AddAsync(enrollment);
            return enrollment;
        }

        public async Task<List<Enrollment>> GetEnrollmentsAsync()
        {
            return await _repository.GetEnrollmentsAsync();
        }
    }
}
