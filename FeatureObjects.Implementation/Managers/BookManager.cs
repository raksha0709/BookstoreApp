using DataStore.Abstraction.Models;
using DataStore.Abstraction.Repositories;
using FeatureObjects.Abstraction.Managers;
using FeatureObjects.Abstraction.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureObjects.Implementation.Managers
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDto> AddBookAsync(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title) ||
                string.IsNullOrWhiteSpace(book.Author) ||
                book.Price <= 0 ||
                book.Stock < 0)
            {
                throw new ArgumentException("Invalid book details provided.");
            }

            var book_id = await _bookRepository.AddBookAsync(book);
            return new BookDto
            {
                BookId = book_id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                Stock = book.Stock,
                Description = book.Description,
                PublishedDate = book.PublishedDate,
                ImageUrl = book.ImageUrl
            };
        }

        public async Task<bool> DeleteBook(int id)
        {
            var existing_book = await _bookRepository.GetBookByIdAsync(id);
            if (existing_book == null)
            {
                return false;
            }

            return await _bookRepository.DeleteBookAsync(id);
        }

        public async Task<BookDto> GetBookByIdAsync(int Id)
        {
            var book = await _bookRepository.GetBookByIdAsync(Id);
            if (book == null) return null;

            return new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                Stock = book.Stock,
                Description = book.Description,
                PublishedDate = book.PublishedDate,
                ImageUrl = book.ImageUrl
            };
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            if (books == null || !books.Any())
            {
                Console.WriteLine("No books found in the database.");
                return Enumerable.Empty<BookDto>();
            }

            return books.Select(book => new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                Stock = book.Stock,
                Description = book.Description,
                PublishedDate = book.PublishedDate,
                ImageUrl = book.ImageUrl
            });
        }

        public async Task<bool> UpdateBookAsync(BookDto bookDto)
        {
            var existing_book = await _bookRepository.GetBookByIdAsync(bookDto.BookId);
            if (existing_book == null)
            {
                return false;
            }
            existing_book.Title = bookDto.Title;
            existing_book.Author = bookDto.Author;
            existing_book.Price = bookDto.Price;
            existing_book.Stock = bookDto.Stock;
            existing_book.Description = bookDto.Description;
            existing_book.PublishedDate = bookDto.PublishedDate;
            existing_book.ImageUrl = bookDto.ImageUrl;

            return await _bookRepository.UpdateBookAsync(existing_book);
        }
    }
}
