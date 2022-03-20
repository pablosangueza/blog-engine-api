using System.Collections.Generic;
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
        [HttpGet("GetPosts")]
        public IEnumerable<string> GetPosts()
        {
            return new List<string>();
        }
        [HttpPost("ApproveRejectPost")]
        public IActionResult ApprovePost()
        {
            return Ok();
        }
      



    }
}