using M.E.J_PropertyWebsite.Server.Database;
using M.E.J_PropertyWebsite.Server.DTO;
using M.E.J_PropertyWebsite.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace M.E.J_PropertyWebsite.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AzureDBContext _context;

        public LoginController(AzureDBContext context)
        {
            _context = context;
        }

		[HttpPost("login")]
		public IActionResult Login([FromBody] LogingRequestDTO loginRequest)
		{
			if (loginRequest == null || string.IsNullOrEmpty(loginRequest.UserName) || string.IsNullOrEmpty(loginRequest.Password))
			{
				return BadRequest("Username or password is missing.");
			}

			var admin = _context.Admin.FirstOrDefault(a => a.UserName == loginRequest.UserName && a.Password == loginRequest.Password);

			if (admin == null || !VerifyPassword(loginRequest.Password, admin.Password))
			{
				return Unauthorized("Invalid username or password.");
			}

			HttpContext.Session.SetString("isAuthenticated", "true");

			var adminDTO = new AdminDTO
            {
                Id = admin.Id,
                UserName = admin.UserName,
                LoginMessage = "Login successful."
            };

			return Ok(adminDTO);
		}

		[HttpPost("logout")]
		public IActionResult Logout() {
			HttpContext.Session.Remove("isAuthenticated");
            return Ok(new { Message = "Logout successful." });
        }

		[HttpGet("isAuthenticated")]
		public IActionResult IsAuthenticated() {
            var isAuthenticated = HttpContext.Session.GetString("isAuthenticated");

            if (isAuthenticated == null)
            {
                return Unauthorized();
            }

            return Ok(new { Message = "User is authenticated." });
        }

        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            //TODO: Implement password hashing
            return enteredPassword == storedPassword;
        }

	}
}
