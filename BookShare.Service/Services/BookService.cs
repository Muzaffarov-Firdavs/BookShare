using BookShare.DataAccess.Repository;
using BookShare.Domain.Enriries;
using BookShare.Service.Commons;
using BookShare.Service.Commons.Exceptions;
using BookShare.Service.DTOs;
using BookShare.Service.Interfaces;
using BookShare.Service.ViewModels;

namespace BookShare.Service.Services;

public class BookService : IBookService
{
    private readonly GenericRepository<Book> _genericRepository;

	public BookService(GenericRepository<Book> genericRepository)
	{
		this._genericRepository = genericRepository;
	}

    public async Task<Book> CreateAsync(BookCreationDto bookDto)
    {
        var books = await this._genericRepository.GetAllAsync();
        var seriachecker = books.FirstOrDefault((s) => s.SeriaNumber == bookDto.SeriaNumber);
        if (seriachecker is not null)
        {
            throw new AlreadyExsistException("User Already exist:");

        }

        var book = (Book)bookDto;

        book.CreatedAt= DateTime.Now;
        book.UpdatedAt= DateTime.Now;

        book.SeriaNumber= bookDto.SeriaNumber;
        

        var respond = await this._genericRepository.CreateAsync(book);
        return respond;
        

    }

    public async Task<bool> DeleteAsync(long id)
    {
        var book = await this._genericRepository.GetByIdAsync(id);

        if (book is not null)
        {
            var respond = await this._genericRepository.DeleteAsync(book.Id);
            return respond;
        }
        else throw new NotFoundException("User not found");
    }

    public async Task<List<BookViewModel>> GetAllAsync()
    {
        var books = await this._genericRepository.GetAllAsync();
        BookViewModel bookViewModel = new BookViewModel();
        List<BookViewModel> models = new List<BookViewModel>();

        foreach (var book in books)
        {
            bookViewModel.Name = book.Name;
            bookViewModel.Edition= book.Edition;
            bookViewModel.Author = book.Author;
            bookViewModel.Year =book.Year;
            bookViewModel.Description = book.Description;

            models.Add(bookViewModel);

        }
        return models;
    }

    public async Task<BookViewModel> GetByIdAsync(long id)
    {
        var model = await this._genericRepository.GetByIdAsync(id);
        if (model is null)
        {
            throw new NotFoundException("User not found");
        }
        BookViewModel bookViewModel = new BookViewModel();

        bookViewModel.Name = model.Name;
        bookViewModel.Edition = model.Edition;
        bookViewModel.Author = model.Author;
        bookViewModel.Year = model.Year;
        bookViewModel.Description = model.Description;

        return bookViewModel;


    }

    public async Task<Book> UpdateAsync(long id, BookCreationDto bookDto)
    {
        var model = await this._genericRepository.GetByIdAsync(id);
        if (model is not null)
        {
            var book = (Book)bookDto;
            book.CreatedAt = DateTime.UtcNow;
            book.UpdatedAt = DateTime.UtcNow;

            book.SeriaNumber= bookDto.SeriaNumber;

            var respond = await this._genericRepository.UpdateAsync(id, book);
            return respond;
        }
        else
        {
            throw new NotFoundException("User not found:");
        }
    }
}
