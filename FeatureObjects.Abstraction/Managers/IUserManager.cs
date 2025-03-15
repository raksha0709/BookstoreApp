using FeatureObjects.Abstraction.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureObjects.Abstraction.Managers
{
    public interface IUserManager
    {
        Task<bool> RegisterUser(RegisterRequest request);
        Task<AuthResponse?> LoginUserAsync(LoginRequest request);
    }
}
