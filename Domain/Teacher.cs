namespace MakerMusic.Api.Domain
{
    public class Teacher
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Bio { get; private set; } = string.Empty;
        public List<Course> Courses { get; set; } = new List<Course>();


        public Teacher(string name, string email, string bio)
        {
            Validate(name, email, bio);

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Bio = bio;
        }

        public void UpdateDetails(string name, string email, string bio)
        {
            Validate(name, email, bio);

            Name = name;
            Email = email;
            Bio = bio;
        }

        private void Validate(string name, string email, string bio)
        {
            if (name == null || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("O nome não pode ser vazio.");
            }
            if (email == null || string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("O email não pode ser vazio.");
            }
            if (bio == null || string.IsNullOrWhiteSpace(bio))
            {
                throw new ArgumentException("A bio não pode ser vazia.");
            }
        }
    }
}
