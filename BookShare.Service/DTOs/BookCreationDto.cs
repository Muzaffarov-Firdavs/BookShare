
using BookShare.Domain.Enriries;

namespace BookShare.Service.DTOs;

public class BookCreationDto
{
    public string Name { get; set; } = string.Empty;
    public string SeriaNumber { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Edition { get; set; }
    public string Year { get; set; } = string.Empty;

    public static implicit operator Book(BookCreationDto dto)
    {
        return new Book()
        {
            Name = dto.Name,
            SeriaNumber = dto.SeriaNumber,
            Price = dto.Price,
            Author = dto.Author,
            Description = dto.Description,
            Edition = dto.Edition,
            Year = dto.Year,

        };
    }

}

