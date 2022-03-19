using System.Linq;
using System.Threading.Tasks;
using BlogEngine.Domain;

namespace BlogEngine.Repository
{
    public class HardDataRepository : IRepository
    {
        public async Task<User> GetUserBy(string username, string password)
        {
            User result = null;
            
            result =  HardCodeData.Users.Where( u=>u.Username == username && u.Password == password).FirstOrDefault();

            return result;

        }
    }
}