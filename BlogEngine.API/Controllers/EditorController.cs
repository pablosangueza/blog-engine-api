using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlogEngine.API.DTOs;
using BlogEngine.Domain;
using BlogEngine.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.API.Controllers
{
    [Authorize(Roles = "Editor")]
    [ApiController]
    [ApiVersion("1")]
    [Route("[controller]")]
    public class EditorController : ControllerBase
    {
        private IEditorService _editorService;

        public EditorController(IEditorService editorService)
        {
            _editorService = editorService;
        }
        [HttpGet("GetPosts")]
        public async Task<IActionResult> GetPosts()
        {

            IList<BlogPost> posts = await _editorService.GetAllPendingToApprovalPosts();
            if (posts != null)
                return Ok(posts.Select(p => new { Title = p.Title, Author = p.Author.Name, Text = p.Text, Status = p.Status.ToString(), Comments = p.Comments }));
            else
                return NotFound(new { message = $"There is not any post to approve" });

        }
        [HttpPost("ApproveRejectPost")]
        public async Task<IActionResult> ApprovePost([FromBody] ApproveRejectDto aprovedRejected)
        {
            string status = aprovedRejected.Approved ? PostStatus.Approved.ToString() : PostStatus.Rejected.ToString();
            try
            {
                await _editorService.ApprovePost(aprovedRejected.Title, aprovedRejected.Approved, aprovedRejected.Comment);
                return Ok(new { message = $"Post {aprovedRejected.Title} was {status}" });

            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });

            }
        }




    }
}