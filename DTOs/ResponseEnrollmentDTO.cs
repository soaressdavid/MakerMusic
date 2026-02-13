using MakerMusic.Api.Domain;

namespace MakerMusic.Api.DTOs
{
    public class ResponseEnrollmentDTO
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public decimal Price { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ResponseStudentDTO? StudentDTO { get; set; }
        public ResponseCourseDTO? CourseDTO { get; set; }

        public ResponseEnrollmentDTO(Guid id, Guid studentId, Guid courseId, decimal price, DateTime enrollmentDate, ResponseStudentDTO? studentDTO, ResponseCourseDTO? course)
        {
            Id = id;
            StudentId = studentId;
            CourseId = courseId;
            Price = price;
            EnrollmentDate = enrollmentDate;
            StudentDTO = studentDTO;
            CourseDTO = course;
        }
    }
}
