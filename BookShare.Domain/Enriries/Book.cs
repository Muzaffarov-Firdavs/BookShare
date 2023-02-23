using BookShare.Domain.Commons;

namespace BookShare.Domain.Enriries;

public class Book : Auditable
{
    public string Name { get; set; } = string.Empty;
    public string SeriaNumber { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Edition { get; set; }
    public string Year { get; set; } = string.Empty;
}
