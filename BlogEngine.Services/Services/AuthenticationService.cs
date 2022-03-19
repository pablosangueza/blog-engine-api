using System;
using System.Threading.Tasks;
using BlogEngine.Domain;
using BlogEngine.Repository;
using BlogEngine.Services.Interfaces;

namespace BlogEngine.Services.Services
{
    public class AuthenticationService : IAuthService
    {
        private IRepository _reopsitory;

        public AuthenticationService(IRepository repository)
        {
            _reopsitory = repository;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            User user = null;

            user = await _reopsitory.GetUserBy(username,password);

            
            return user;
        }
    }
}
