using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtisoraServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController:ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public LoginController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetByID(string email)
        {
            try
            {
                var currentLogin = await _context.Logins.FirstOrDefaultAsync(a => a.email.Equals(email));
                return Ok(currentLogin);
            }
            catch
            {
                return BadRequest("Mentee couldn't be found");
            }
        }
    }
}
