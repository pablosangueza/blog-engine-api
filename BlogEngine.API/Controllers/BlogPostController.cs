using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogEngine.API.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1")]
    [Route("[controller]")]
    public class BlogPostController : ControllerBase
    {

        private readonly ILogger<BlogPostController> _logger;

        public BlogPostController(ILogger<BlogPostController> logger)
        {
            _logger = logger;
        }

        [HttpGet("HealthCheck")]
        public string HealthCheck()
        {
            return "Hello world from Blog Engine";
        }

        [HttpGet("ListPosts")]
        public IEnumerable<string> GetAllPosts()
        {
            return new List<string>();
        }

        [HttpPost("CommentPost")]
        public IActionResult CommentPost()
        {
            return Ok("done");
        }
    }
}
