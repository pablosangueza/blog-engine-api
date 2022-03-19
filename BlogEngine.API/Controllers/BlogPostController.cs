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
    [Authorize( AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Editor")]
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

        [HttpGet]
        
        public IEnumerable<string> Get()
        {
            var list =new List<string>();
            list.Add("test1");
            list.Add("test2");
            list.Add("test3");


            
            return list;
        
        }
    }
}
