using BookShare.Domain.Enriries;
using BookShare.Service.DTOs;
using BookShare.Service.ViewModels;

namespace BookShare.Service.Interfaces
{
    public interface IBookService
    {
        public Task<Book> CreateAsync(BookCreationDto book);
        public Task<Book> UpdateAsync(long id, BookCreationDto book);
        public Task<bool> DeleteAsync(long id);
        public Task<BookViewModel> GetByIdAsync(long id);
        public Task<List<BookViewModel>> GetAllAsync();
    }
}
