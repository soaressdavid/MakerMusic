using MakerMusic.Api.Domain;
using MakerMusic.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MakerMusic.Api.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _context;
        public EnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Enrollment?> AddAsync(Enrollment enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<bool> VerifyEnrollmentAsync(Guid studentId, Guid courseId)
        {
            return await _context.Enrollments.AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);
        }

        public async Task<List<Enrollment>> GetEnrollmentsAsync()
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToListAsync();
        }
    }
}

