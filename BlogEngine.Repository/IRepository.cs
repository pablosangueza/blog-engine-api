using System.Collections.Generic;
using System.Threading.Tasks;
using BlogEngine.Domain;

namespace BlogEngine.Repository
{
    public interface IRepository
    {
        Task<User> GetUserBy(string username, string password);
        Task<IList<BlogPost>> GetAllBlogPosts();
        Task<BlogPost> GetPostByTitle(string title);
        Task<User> GetUser(string username);
        Task<bool> AddPost(BlogPost post);
        Task Update(BlogPost post);
    }
}