using System.Xml.Linq;

namespace MakerMusic.Api.Domain
{
    public class Course
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public Guid TeacherId { get; private set; }
        public Teacher? Teacher { get; set; }
        public Course(string title, string description, decimal price, Guid teacherId)
        {
            Validate(title, description, price, teacherId);

            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Price = price;
            TeacherId = teacherId;
        }
        public void UpdateDetails(string title, string description, decimal price)
        {
            Validate(title, description, price);

            Title = title;
            Description = description;
            Price = price;
        }

        private void Validate(string title, string description, decimal price, Guid? teacherId = null)
        {
            if (title == null || string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("O título não pode ser vazio.");
            }
            if (description == null || string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("A descrição não pode ser vazia.");
            }
            if (decimal.IsNegative(price))
            {
                throw new ArgumentException("O preço não pode ser menor que 0.");
            }
            if (teacherId.HasValue && teacherId.Value == Guid.Empty)
            {
                throw new ArgumentException("O ID é inválido!");
            }
        }
    }
}
