using MakerMusic.Api.Domain;
using MakerMusic.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MakerMusic.Api.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;
        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> GetAllTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher?> AddTeacherAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return teacher;

        }

        public async Task<Teacher?> GetTeacherById(Guid id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<bool> UpdateTeacherAsync(Guid id, Teacher teacher)
        {
            var existingTeacher = await _context.Teachers.FindAsync(id);
            if (existingTeacher == null) return false;

            existingTeacher.UpdateDetails(teacher.Name, teacher.Email, teacher.Bio);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTeacherAsync(Guid id)
        {
            var existingTeacher = await _context.Teachers.FindAsync(id);
            if (existingTeacher == null) return false;

            _context.Teachers.Remove(existingTeacher);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
