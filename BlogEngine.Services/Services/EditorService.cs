using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogEngine.Domain;
using BlogEngine.Repository;
using BlogEngine.Services.Interfaces;
using System;

namespace BlogEngine.Services.Services
{
    public class EditorService : IEditorService
    {
        private IRepository _repository;

        public EditorService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ApprovePost(string title, bool approveReject, string comment)
        {
            var post = await _repository.GetPostByTitle(title);
            if (post != null)
            {
                post.Status = approveReject ? PostStatus.Approved : PostStatus.Rejected;
                if(post.Status == PostStatus.Rejected)
                    post.EditorComments.Add(comment);
                await _repository.Update(post);
            }
            else
                throw new Exception($"There is no a Post with title \"{title}\" for to Appprove");

        }

        public async Task<IList<BlogPost>> GetAllPendingToApprovalPosts()
        {
            IList<BlogPost> posts = await _repository.GetAllBlogPosts();
            return posts.Where(p => p.Status == PostStatus.Pending).ToList();
        }
    }
}