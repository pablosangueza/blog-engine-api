using System.Collections.Generic;
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
        
        [HttpGet("GetPosts")]
        public IEnumerable<string> GetPosts()
        {
            return new List<string>();
        }

        [HttpPost("CreatePost")]
        public IActionResult CreatePost()
        {
            return Ok();
        }

        [HttpPut("EditPost")]
        public IActionResult EditPost()
        {
            return Ok();
        }

        [HttpGet("SubmitPost")]
        public IActionResult SubmitPost()
        {
            return Ok();
        }
        
    }
}