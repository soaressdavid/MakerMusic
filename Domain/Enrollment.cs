namespace MakerMusic.Api.Domain
{
    public class Enrollment
    {
        public Guid Id { get; private set; }
        public Guid StudentId { get; private set; }
        public Guid CourseId { get; private set; }
        public decimal Price { get; private set; }
        public DateTime EnrollmentDate { get; private set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }

        public Enrollment(Guid studentId, Guid courseId, decimal price)
        {
            if(studentId == Guid.Empty)
            {
                throw new ArgumentException("O aluno é inválido.");
            }
            if (courseId == Guid.Empty)
            {
                throw new ArgumentException("O curso é inválido.");
            }
            if (decimal.IsNegative(price))
            {
                throw new ArgumentException("O preço não pode ser menor que 0.");
            }

            Id = Guid.NewGuid();
            EnrollmentDate = DateTime.UtcNow;
            StudentId = studentId;
            CourseId = courseId;
            Price = price;
        }
    }
}
