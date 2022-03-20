using System.Collections.Generic;
using System.Threading.Tasks;
using BlogEngine.Domain;

namespace BlogEngine.Services.Interfaces
{
    public interface IEditorService
    {
        Task<IList<BlogPost>> GetAllPendingToApprovalPosts();
        Task ApprovePost(string title, bool approveReject,  string comment);
    }
}