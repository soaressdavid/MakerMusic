using MakerMusic.Api.Domain;

namespace MakerMusic.Api.DTOs
{
    public class CreateCourseDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid TeacherId { get; set; }
    }
}
