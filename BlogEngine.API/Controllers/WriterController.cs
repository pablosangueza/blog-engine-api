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
    [Authorize(Roles = "Writer")]
    [ApiController]
    [ApiVersion("1")]
    [Route("[controller]")]
    public class WriterController : ControllerBase
    {
        private IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet("GetPosts")]
        public async Task<IActionResult> GetPosts()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var username = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                IList<BlogPost> posts = await _writerService.GetPostsOfUserName(username);
                if (posts != null)
                    return Ok(posts.Select(p => new { Title = p.Title, Author = p.Author.Name, Text = p.Text, Status = p.Status.ToString(), Comments = p.Comments }));
                else
                    return NotFound(new { message = $"There is not any post for {username}" });
            }

            return NoContent();
        }

        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost([FromBody] PostDto newPost)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var username = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                bool res = await _writerService.AddNewPost(username, newPost.Title, newPost.Text);
                if (res)
                    return Ok(new { message = $"Post {newPost.Title} was created." });
                else
                    return BadRequest(new { message = "There was an error on post creation" });

            }
            return NoContent();

        }

        [HttpPut("EditPost")]
        public async Task<IActionResult> EditPost([FromBody] PostDto post)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            try
            {
                if (identity != null)
                {
                    var username = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                    await _writerService.EditPost(username, post.Title, post.Text);
                    return Ok(new { message = $"Post {post.Title} was updated" });

                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return NoContent();
        }

        [HttpPost("SubmitPost")]
        public async Task<IActionResult> SubmitPost([FromForm] string title)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            try
            {
                if (identity != null)
                {
                    var username = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                    await _writerService.SubmitPost(username, title);
                    return Ok(new { message = $"Post {title} was Submited" });

                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return NoContent();
        }

    }
}