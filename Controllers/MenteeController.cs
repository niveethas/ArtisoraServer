
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtisoraServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MenteeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public MenteeController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet("/all")]
        public async Task<mentee> GetAll()
        {
            
                var allMentee = await _context.Mentees.FirstAsync();
                return allMentee;
            
            
        }

        [HttpGet("/user")]
        public async Task<IActionResult> GetByID(string email)
        {
            try
            {
                var currentMentee = await _context.Mentees.FirstOrDefaultAsync(a => a.email.Equals(email));
                return Ok(currentMentee);
            }
            catch
            {
                return BadRequest("Mentee couldn't be found");
            }
        }

        [HttpPost]
        public async Task<IActionResult> NewMentee(mentee newM)
        {
            try
            {
                _context.Add(newM);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest("Sign up has failed.");
            }
        }

    }

   
}
