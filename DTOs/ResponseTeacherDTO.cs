namespace MakerMusic.Api.DTOs
{
    public class ResponseTeacherDTO
    {
        public ResponseTeacherDTO(Guid id, string name, string email, string bio)
        {
            Id = id;
            Name = name;
            Email = email;
            Bio = bio;
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
    }
}
