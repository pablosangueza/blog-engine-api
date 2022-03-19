using System.Threading.Tasks;
using BlogEngine.Domain;

namespace BlogEngine.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Authenticate(string username, string password);
    }
}