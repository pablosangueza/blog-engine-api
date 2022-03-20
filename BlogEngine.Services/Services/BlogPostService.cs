using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogEngine.Domain;
using BlogEngine.Repository;
using BlogEngine.Services.Interfaces;

namespace BlogEngine.Services.Services
{
    public class BlogPostService : IBlogPostService
    {
        private IRepository _repository;

        public BlogPostService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddComment(string title, string comment)
        {
            BlogPost post = await _repository.GetPostByTitle(title);
            if (post != null && post.Status == PostStatus.Approved)
            {
                post.Comments.Add(comment);
                return true;
            }
            else
                return false;

        }

        public async Task<IList<BlogPost>> GetAllPublishedPosts()
        {
            var allPosts = await _repository.GetAllBlogPosts();
            return allPosts.Where(p => p.Status == PostStatus.Approved).ToList();
        }
    }
}