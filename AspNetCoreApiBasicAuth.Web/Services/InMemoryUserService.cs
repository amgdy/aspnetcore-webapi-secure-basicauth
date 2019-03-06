using System;
using System.Collections.Concurrent;
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
            { "admin", "dj9Kek1EJHlYJDk/V05Kag==" }, // P@ssw0rd  
            { "user1",  "UEBzc3cwcmQ=" }// v?JzMD$yX$9?WNJj
        };

        public async Task<bool> ValidateAsync(string username, string password)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var encodedPassword = Convert.ToBase64String(passwordBytes);

            return await _notSecureStore
                .ToAsyncEnumerable()
                .Any(c => c.Key.Equals(username, StringComparison.InvariantCultureIgnoreCase) && c.Value == encodedPassword);
        }
    }
}
