using System;
using System.Net.Mime;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogEngine.Domain;
using BlogEngine.Repository;
using BlogEngine.Services.Interfaces;

namespace BlogEngine.Services.Services
{
    public class WriterService : IWriterService
    {
        private IRepository _repository;

        public WriterService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddNewPost(string username, string title, string text)
        {
            User user = await _repository.GetUser(username);
            if (user != null)
            {
                BlogPost post = new BlogPost()
                {
                    Author = user,
                    Title = title,
                    Text = text,
                    Comments = new List<string>(),
                    PublishDate = DateTime.Now,
                    Status = PostStatus.Pending,
                };
                return await _repository.AddPost(post);
            }
            else
                return false;

        }

        public async Task EditPost(string username, string title, string text)
        {
            User user = await _repository.GetUser(username);
            IList<BlogPost> posts = await GetPostsOfUserName(username);
            var postWithTitle = posts.Where(p => p.Title == title && p.Status == PostStatus.Editing).SingleOrDefault();
            if (postWithTitle != null)
            {
                postWithTitle.Text = text;
                postWithTitle.Status = PostStatus.Editing;
                await _repository.Update(postWithTitle);
            }
            else
                throw new Exception("There is no a Post with that title to edit or update");

        }

        public async Task<IList<BlogPost>> GetPostsOfUserName(string username)
        {
            User user = await _repository.GetUser(username);
            if (user != null)
            {
                IList<BlogPost> posts = await _repository.GetAllBlogPosts();
                return posts.Where(p => p.Author.Name == user.Name).ToList();
            }
            else
                return null;
        }

        public async Task SubmitPost(string username, string title)
        {
            User user = await _repository.GetUser(username);
            IList<BlogPost> posts = await GetPostsOfUserName(username);
            var postWithTitle = posts.Where(p => p.Title == title && p.Status == PostStatus.Editing).SingleOrDefault();
            if (postWithTitle != null)
            {
                postWithTitle.Status = PostStatus.Pending;
                await _repository.Update(postWithTitle);
            }
            else
                throw new Exception($"There is no a Post with title \"{title}\" for to submit");

        }
    }
}