namespace MakerMusic.Api.DTOs
{
    public class ResponseStudentDTO
    {
        public ResponseStudentDTO(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}