using ApplicationLayer.DTOs;
using ApplicationLayer.Service.Contract;
using DomainLayer.Entities;
using DomainLayer.Interfaces;
using InfrastructureLayer.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ApplicationLayer.Service.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateBookAsync(BookDto bookDto)
        {
            var book = new Book(
                bookDto.Id,
                bookDto.Title,
                bookDto.Author,
                bookDto.Publisher,
                bookDto.Available,
                bookDto.Price,
                bookDto.CreatedOn,
                bookDto.IsActive,
                bookDto.GenreID
            );

            await _unitOfWork.Books.CreateAsync(book);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteBookAsync(object id)
        {
            await _unitOfWork.Books.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<BookDto> GetBookByIdAsync(object id)
        {
            var bookEntity = await _unitOfWork.Books.GetByIdAsync(id);
            if (bookEntity == null) return null;

            var bookDto = new BookDto(
                bookEntity.Id,
                bookEntity.Title,
                bookEntity.Author,
                bookEntity.Publisher,
                bookEntity.Available,
                bookEntity.Price,
                bookEntity.CreatedOn,
                bookEntity.IsActive,
                bookEntity.GenreID
            );

            return bookDto;
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            IEnumerable<Book> books = await _unitOfWork.Books.GetAllAsync();

            var bookDtos = books.Select(book => new BookDto(
                book.Id,
                book.Title,
                book.Author,
                book.Publisher,
                book.Available,
                book.Price,
                book.CreatedOn,
                book.IsActive,
                book.GenreID
            ));

            return bookDtos;
        }

        public async Task UpdateBookAsync(BookDto bookDto)
        {
            var bookEntity = new Book(
                bookDto.Id,
                bookDto.Title,
                bookDto.Author,
                bookDto.Publisher,
                bookDto.Available,
                bookDto.Price,
                bookDto.CreatedOn,
                bookDto.IsActive,
                bookDto.GenreID
            );

            await _unitOfWork.Books.UpdateAsync(bookEntity);
            await _unitOfWork.CompleteAsync();
        }
    }
}
