using MakerMusic.Api.Domain;
using MakerMusic.Api.DTOs;

namespace MakerMusic.Api.Services
{
    public interface IEnrollmentService
    {
        Task<Enrollment?> CreateEnrollmentAsync(Guid studentId, Guid courseId);
        Task<List<ResponseEnrollmentDTO?>> GetEnrollmentsAsync();
        Task<bool> CancelEnrollmentAsync(Guid id);
    }
}
