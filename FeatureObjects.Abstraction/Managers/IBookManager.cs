using FeatureObjects.Abstraction.ViewModels;
using DataStore.Abstraction.Models;

namespace FeatureObjects.Abstraction.Managers
{
    public interface IBookManager
    {
        Task<BookDto> AddBookAsync(Book book);
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto?> GetBookByIdAsync(int Id);
        Task<bool> UpdateBookAsync(BookDto bookDto);
        Task<bool> DeleteBook(int Id);
    }
}
