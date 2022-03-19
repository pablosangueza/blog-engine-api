using System.Threading.Tasks;
using BlogEngine.Domain;

namespace BlogEngine.Repository
{
    public interface IRepository
    {
        Task<User> GetUserBy(string username, string password);
    }
}