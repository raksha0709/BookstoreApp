using DataStore.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Abstraction.Repositories
{
    public interface IUserRepository
    {
        Task <User?> GetUserByEmailAsync (string email);
        Task<bool> RegisterUser(User user);

    }
}
