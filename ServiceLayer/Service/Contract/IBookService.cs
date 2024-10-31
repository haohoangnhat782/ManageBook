using ApplicationLayer.DTOs;

namespace ApplicationLayer.Service.Contract
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();
        Task<BookDto> GetBookByIdAsync(object id);
        Task CreateBookAsync(BookDto book);
        Task UpdateBookAsync(BookDto book);
        Task DeleteBookAsync(object id);

    }
}