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

        //finding a login by email
        [HttpGet("/user/password")]
        public async Task<login> GetPasswordByEmail(string email)
        {
            var currentLogin = await _context.Logins.FirstOrDefaultAsync(a => a.email.Equals(email));
            return currentLogin;
        }

        //return a role by email
        [HttpGet("/user/role")]
        public async Task<int> GetRoleByEmail(string email)
        {
            var currentRole = await _context.Logins.FirstOrDefaultAsync(a => a.email.Equals(email));
            return currentRole.role;
        }

    }
}
