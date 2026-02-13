namespace MakerMusic.Api.DTOs
{
    public class ResponseCourseDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid TeacherId { get; set; }

        public ResponseCourseDTO(Guid id, string title, string description, decimal price, Guid teacherId)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            TeacherId = teacherId;
        }
    }
}
