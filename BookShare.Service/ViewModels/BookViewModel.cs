using BookShare.Domain.Enriries;
using BookShare.Service.DTOs;

namespace BookShare.Service.ViewModels
{
    public class BookViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Edition { get; set; }
        public string Year { get; set; } = string.Empty;


        public static implicit operator Book(BookViewModel dto)
        {
            return new Book()
            {
                Name = dto.Name,
                Author = dto.Author,
                Price = dto.Price,
                Description = dto.Description,
                Edition = dto.Edition,
                Year = dto.Year,

            };
        }
    }
}
