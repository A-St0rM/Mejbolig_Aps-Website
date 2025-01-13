using M.E.J_PropertyWebsite.Server.Database;
using M.E.J_PropertyWebsite.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace M.E.J_PropertyWebsite.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ServerDBContext _context;

        public LoginController(ServerDBContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Admin loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.UserName) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Username or password is missing.");
            }

            // Validate the admin credentials
            var admin = _context.Admins.FirstOrDefault(a => a.UserName == loginRequest.UserName && a.Password == loginRequest.Password);

            if (admin == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(new { Message = "Login successful!" });
        }
    }
}
