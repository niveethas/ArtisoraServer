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
        [HttpGet("/user/login")]
        public async Task<login> GetLoginInfoByEmail(string email)
        {
            try
            {
                var currentLogin = await _context.Logins.FirstOrDefaultAsync(a => a.email.Equals(email));
                return currentLogin;
            }
            catch
            {
                return null;
            }
        }

       

    }
}
