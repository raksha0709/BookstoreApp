using DataStore.Abstraction.Models;
using DataStore.Abstraction.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataStore.Implementation.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString;
        public BookRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<int> AddBookAsync(Book book)
        {
            var sql = @"INSERT INTO Books(Title,Author,Price,Stock,Description,PublishedDate,ImageUrl) Values(@Title,@Author,@Price,@Stock,@Description,@PublishedDate,@ImageUrl); SELECT SCOPE_IDENTITY();";
            using(var connection=new SqlConnection(_connectionString))
            {
                var result=await connection.ExecuteScalarAsync<int>(sql,book);
                return result;
            }
        }

        public async Task<bool> DeleteBookAsync(int Id)
        {
            var sql = @"DELETE FROM Books WHERE BookId=@BookId;";
            using( var connection=new SqlConnection(_connectionString))
            {
                var rows_Effected=await connection.ExecuteAsync(sql,new {BookId=Id});
                return rows_Effected > 0;
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            var sql = @"SELECT * FROM Books;";
            using(var  connection=new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Book>(sql);
            }
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            var sql = @"SELECT * FROM Books where BookId=@BookId;";
            using(var connection=new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Book>(sql, new {BookId=id});
            }
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            var sql = @"
        UPDATE Books 
        SET 
            Title = @Title, 
            Author = @Author, 
            Price = @Price, 
            Stock = @Stock, 
            Description = @Description, 
            PublishedDate = @PublishedDate, 
            ImageUrl = @ImageUrl
        WHERE BookId = @BookId;";

            using (var connection = new SqlConnection(_connectionString))
            {
                var rowsAffected = await connection.ExecuteAsync(sql, book);
                return rowsAffected > 0;
            }
        }
    }
}
