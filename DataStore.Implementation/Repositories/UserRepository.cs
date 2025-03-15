using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStore.Abstraction.Repositories;
using Dapper;
using DataStore.Abstraction.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataStore.Implementation.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(IConfiguration configuration)
        {
             _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var sql = @"select * from Users where Email=@Email";
            using(var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Email = email });
            }
        }

        public async Task<bool> RegisterUser(User user)
        {
            var sql = @"INSERT INTO Users (Username, Email, PasswordHash, Role, CreatedAt)
                VALUES (@Username, @Email, @PasswordHash, @Role, GETDATE())";

            using (var connection = new SqlConnection(_connectionString))
            {
                var rowsAffected = await connection.ExecuteAsync(sql,user); 
                return rowsAffected > 0;
            }
        }
    }
}
