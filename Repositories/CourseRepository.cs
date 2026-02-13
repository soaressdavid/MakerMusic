using MakerMusic.Api.Domain;
using MakerMusic.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MakerMusic.Api.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _context.Courses
                                 .Include(c => c.Teacher)
                                 .ToListAsync();
        }

        public async Task<Course?> GetCourseById(Guid id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<Course?> AddCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<bool> UpdateCourseAsync(Guid id, Course course)
        {
            var existingCourse = await _context.Courses.FindAsync(id);
            if (existingCourse is null) return false;
            existingCourse.UpdateDetails(course.Title, course.Description, course.Price);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCourseAsync(Guid id)
        {
            var existingCourse = await _context.Courses.FindAsync(id);
            if (existingCourse is null) return false;

            _context.Courses.Remove(existingCourse);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
