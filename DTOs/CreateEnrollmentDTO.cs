namespace MakerMusic.Api.DTOs
{
    public class CreateEnrollmentDTO
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
    }
}
