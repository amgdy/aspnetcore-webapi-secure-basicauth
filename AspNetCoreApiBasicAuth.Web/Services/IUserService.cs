using System.Threading.Tasks;

namespace AspNetCoreApiBasicAuth.Web.Services
{
    public interface IUserService
    {
        Task<bool> ValidateAsync(string username, string password);
    }
}
