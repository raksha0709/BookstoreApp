using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureObjects.Abstraction.ViewModels
{
    public class AuthResponse
    {
        public int Id { get; set; }          // User ID
        public string Email { get; set; }    // User's Email
        public string Role { get; set; }     // User's Role
        public string Token { get; set; }
    }
}
