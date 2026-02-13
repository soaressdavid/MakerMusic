namespace MakerMusic.Api.Domain
{
    public class Student
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }
        public List<Enrollment> Enrollments { get; private set; } = new List<Enrollment>();

        public Student(string name, string email, string passwordHash)
        {
            if (name == null || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("O nome é obrigatório!");
            }
            if (email == null || string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("O email é obrigatório!");
            }
            if (passwordHash == null || string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new ArgumentException("A senha é obrigatória!");
            }

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            IsActive = true;
        }

        public void UpdateDatas(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
