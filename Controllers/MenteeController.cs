
using ArtisoraServer.DTOs;
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


        //returns all mentees
        [HttpGet("/all")]
        public async Task<List<mentee>> GetAll()
        {
            var allMentee = await _context.Mentees.ToListAsync();
            return allMentee;
        }

        //finding a mentee by email
        [HttpGet("/mentee")]
        public async Task<mentee> GetByEmail(string email)
        {
            var currentMentee = await _context.Mentees.FirstAsync(a => a.email.Equals(email));
            return currentMentee;

        }

        //returning mentee id by email
        [HttpGet("/mentee/id")]
        public async Task<int> GetId(string email)
        {
            var currentMentor = await _context.Mentees.FirstAsync(a => a.email.Equals(email));
            return currentMentor.menteeId;
        }


        //registering a new mentee
        [HttpPost("/mentee/new")]
        public async Task<IActionResult> NewMentee(MenteeDTO newM, login newL)
        {
            try
            {
                // _context.Add(newM);
                var mentee = new mentee
                {
                    firstName = newM.firstName,
                    lastName = newM.lastName,
                    email = newM.email
                };
                _context.Mentees.Add(mentee);
                _context.Logins.Add(newL);
                await _context.SaveChangesAsync();
                return Ok(newM.email);
            }
            catch
            {
                return BadRequest("Sign up has failed.");
            }
        }

        //get all mentorships by menteeid
        [HttpGet("/mentorships/menteeid")]
        public async Task<mentorship> GetMsByID(int id)
        {
            var currentMentorship = await _context.Mentorships.FirstAsync(x => x.menteeId == id);
            return currentMentorship;

        }
        
        //get mentorship id 
        [HttpGet("/mentorships/menteeid/id")]
        public async Task<int> GetMsIDByID(int id)
        {
            var currentMentorship = await _context.Mentorships.FirstAsync(x => x.mentorshipId == id);
            return currentMentorship.mentorshipId;

        }

        //get all images by menteeid
        [HttpGet("/images")]
        public async Task<List<image>> GetIByID(int id)
        {
            var menteeImages = await _context.Images.Where(x => x.menteeId == id).ToListAsync();
            return menteeImages;

        }

        //add new image
        [HttpPost("/images/new")]
        public async Task<IActionResult> NewImage(ImageDTO newI)
        {
            try
            {
                var image = new image
                {
                    mentorshipId = newI.mentorshipId,
                    menteeId = newI.menteeId,
                    imageURL = newI.imageURL
                };
                _context.Images.Add(image);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest("Image upload has failed");
            }
        }

    }
}
