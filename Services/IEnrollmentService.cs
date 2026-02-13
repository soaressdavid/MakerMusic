using MakerMusic.Api.Domain;

namespace MakerMusic.Api.Services
{
    public interface IEnrollmentService
    {
        Task<Enrollment?> CreateEnrollmentAsync(Guid studentId, Guid courseId);
        Task<List<Enrollment>> GetEnrollmentsAsync();
    }
}
