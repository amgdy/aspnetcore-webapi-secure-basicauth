using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreApiBasicAuth.Web.Services
{
    public class InMemoryUserService : IUserService
    {
        private static Dictionary<string, string> _notSecureStore = new Dictionary<string, string>
        {
            // Passwords are base64 encoded for this example
            { "admin", "dj9Kek1EJHlYJDk/V05Kag==" }, // v?JzMD$yX$9?WNJj  
            { "hackitright",  "UEBzc3cwcmQ=" }// P@ssw0rd
        };

        public async Task<bool> ValidateAsync(string username, string password)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var encodedPassword = Convert.ToBase64String(passwordBytes);

            return await _notSecureStore
                .ToAsyncEnumerable()
                .AnyAsync(c => c.Key.Equals(username, StringComparison.InvariantCultureIgnoreCase) && c.Value == encodedPassword);
        }
    }
}
