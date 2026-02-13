using MakerMusic.Api.Domain;
using MakerMusic.Api.DTOs;

namespace MakerMusic.Api.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment?> AddAsync(Enrollment enrollment);
        Task<bool> VerifyEnrollmentAsync(Guid studentId, Guid courseId);
        Task<List<Enrollment>> GetEnrollmentsAsync();
        Task<bool> CancelEnrollmentAsync(Guid id);
    }
}
