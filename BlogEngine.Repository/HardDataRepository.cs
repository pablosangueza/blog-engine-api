using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogEngine.Domain;

namespace BlogEngine.Repository
{
    public class HardDataRepository : IRepository
    {
        public async Task<bool> AddPost(BlogPost post)
        {
            var existencePost = HardCodeData.Posts.Where(p=>p.Title == post.Title).FirstOrDefault();
            if(existencePost !=null)
                return false;
            HardCodeData.Posts.Add(post);
            return true;
        }

        public async Task<IList<BlogPost>> GetAllBlogPosts()
        {
            return HardCodeData.Posts;
        }

        public async Task<BlogPost> GetPostByTitle(string title)
        {
            return HardCodeData.Posts.Where(p=>p.Status == PostStatus.Approved && p.Title == title).FirstOrDefault();

        }

        public async Task<User> GetUser(string username)
        {
           return HardCodeData.Users.Where(u => u.Username == username).FirstOrDefault();
        }

        public async Task<User> GetUserBy(string username, string password)
        {
            User result = null;

            result = HardCodeData.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            return result;

        }

        public async Task Update(BlogPost post)
        {
           var postToUpdate = GetPostByTitle(post.Title);
           
        }
    }
}