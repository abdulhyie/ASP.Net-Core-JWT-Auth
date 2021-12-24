using JWT_AUTH_ASP.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_AUTH_ASP.Controllers
{
    public class CheckAuthController : Controller
    {
        private IJwtAuthenticationManager jwtAuthenticationManager;

        public CheckAuthController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [Authorize]
        [HttpGet("admin")]
        public IActionResult admin()
        {
            return Ok("Admin dashboard");
        }

        [HttpGet("socities")]
        public IActionResult socities()
        {
            return Ok("socities page");
        }


        [HttpPost("authenticate")]
        public IActionResult authenticate()
        {
            // get the token
            var token = jwtAuthenticationManager.Authenticate("DotNetIs", "bad");
            // if not valid, unauthorized
            if (token == null)
                return Unauthorized();
            // else return token

            return Ok(token);
        }
    }
}
