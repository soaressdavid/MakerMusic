using MakerMusic.Api.Domain;
using MakerMusic.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MakerMusic.Api.Repositories
{
    public class StudentsRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> AddStudentAsync(Student newStudent)
        {
            await _context.Students.AddAsync(newStudent);
            await _context.SaveChangesAsync();
            return newStudent;
        }

        public async Task<Student?> GetStudentByIdAsync(Guid id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<bool> UpdateStudentAsync(Guid id, Student student)
        {
            var existingStudent = await _context.Students.FindAsync(id);
            if ( existingStudent == null)
            {
                return false;
            }

            existingStudent.UpdateDatas(student.Name, student.Email);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStudentAsync(Guid id)
        {
            var existingStudent = await _context.Students.FindAsync(id);
            if (existingStudent == null) return false;
            _context.Students.Remove(existingStudent);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
