using MakerMusic.Api.Domain;

namespace MakerMusic.Api.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment?> AddAsync(Enrollment enrollment);
        Task<bool> VerifyEnrollmentAsync(Guid studentId, Guid courseId);
        Task<List<Enrollment>> GetEnrollmentsAsync();
    }
}
