using System.Collections.Generic;
using System.Threading.Tasks;
using BlogEngine.Domain;

namespace BlogEngine.Services.Interfaces
{
    public interface IWriterService
    {
        Task<IList<BlogPost>> GetPostsOfUserName(string username);
        Task<bool> AddNewPost(string username, string title, string text);
        Task EditPost(string username, string title, string text);
    }
}