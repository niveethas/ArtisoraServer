using ArtisoraServer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtisoraServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly ApplicationDBContext _context;
        public MessageController(ApplicationDBContext context)
        {
            this._context = context;
        }

        //messages by mentorshipid
        [HttpGet("/messages/mentorship")]
        public async Task<List<message>> GetMessageByID(int id)
        {
            var message = await _context.Messages.Where(x => x.mentorshipId == id).ToListAsync();
            return message;

        }

        //return all the messages for an image
        [HttpGet("/messages")]
        public async Task<List<message>> GetMessageByImage(int id)
        {
            return await _context.Messages.Where(x => x.imageId == id).ToListAsync();
        }

        //new message
        [HttpPost("/messages/new")]
        public async Task<IActionResult> NewMessage(MessageDTO newMsg)
        {
            try
            {
                var message = new message
                {
                    mentorshipId = newMsg.mentorshipId,
                    textContent = newMsg.textContent,
                    imageId = newMsg.imageId

                };
                _context.Messages.Add(message);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest("New comment could not be saved.");
            }
        }


    }
}
