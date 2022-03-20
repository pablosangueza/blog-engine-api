using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEngine.Domain;
using BlogEngine.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BlogEngine.API.Controllers
{
    
    [ApiController]
    [ApiVersion("1")]
    [Route("[controller]")]
    [ControllerName("Authentication")]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private IConfiguration _config; 

        public AuthController(IConfiguration config, IAuthService authService)
        {
            _config = config;
            _authService = authService;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin loginData)
        {
            IActionResult response = Unauthorized();  
            User user = await _authService.Authenticate(loginData.Username,loginData.Password);
            
            if (user != null)  
            {  
                var tokenString = GenerateJSONWebToken(user);  
                response = Ok(new { Token = tokenString , Message = "Success" });  
            }  
            return response; 

        }

        private object GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));  
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);  

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }; 
  
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],  
              _config["Jwt:Issuer"],  
              claims,  
              expires: DateTime.Now.AddMinutes(120),  
              signingCredentials: credentials);  
  
            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
    }
}