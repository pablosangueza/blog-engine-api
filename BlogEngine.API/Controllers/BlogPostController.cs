using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogEngine.API.DTOs;
using BlogEngine.Domain;
using BlogEngine.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace BlogEngine.API.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1")]
    [Route("[controller]")]
    public class BlogPostController : ControllerBase
    {

        private readonly ILogger<BlogPostController> _logger;
        private IBlogPostService _blogPostService;

        public BlogPostController(ILogger<BlogPostController> logger, IBlogPostService blogPostService)
        {
            _logger = logger;
            _blogPostService = blogPostService;
        }

        [HttpGet("HealthCheck")]
        public string HealthCheck()
        {
            return "Hello world from Blog Engine";
        }

        [HttpGet("ListPosts")]
        public async Task<IActionResult> GetAllPostsAsync()
        {
            IList<BlogPost> posts = await _blogPostService.GetAllPublishedPosts();

            return Ok(posts.Select(p => new {Title = p.Title, Author = p.Author.Name, Text = p.Text, Comments = p.Comments}));

        }

        [HttpPost("CommentPost")]
        public async Task<IActionResult> CommentPostAsync([FromBody] CommentDto comment)
        {
            bool res= await _blogPostService.AddComment(comment.Title, comment.Comment);
            if (res)
                return Ok("Comment Added");
            else
                return NotFound("Comment Not Found");
        }
    }
}
