using DataStore.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Abstraction.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllBooksAsync ();
        Task<bool> UpdateBookAsync(Book book);
        Task<bool> DeleteBookAsync(int Id);
        Task<int> AddBookAsync(Book book);

    }
}
