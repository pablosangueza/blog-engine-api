using System.Collections.Generic;
using System.Threading.Tasks;
using BlogEngine.Domain;

namespace BlogEngine.Services.Interfaces
{
    public interface IBlogPostService
    {
        Task<IList<BlogPost>> GetAllPublishedPosts();
        Task<bool> AddComment(string title, string comment);
    }
}