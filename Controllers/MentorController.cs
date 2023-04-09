using ArtisoraServer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtisoraServer.Controllers
{
    public class MentorController : Controller
    {
        private readonly ApplicationDBContext _context;
        public MentorController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet("/mentor/all")]
        public async Task<List<mentor>> GetByAll()
        {
            var allMentors = await _context.Mentors.ToListAsync();
            return allMentors;
        }


        //check mentor email exists
        [HttpGet("/mentor")]
        public async Task<mentor> GetByEmail(string email)
        {
            var currentMentor = await _context.Mentors.FirstOrDefaultAsync(a => a.email.Equals(email));
            return currentMentor;

        }

        //get mentor id by email
        [HttpGet("/mentor/id")]
        public async Task<int> GetId (string email)
        {
            var currentMentor = await _context.Mentors.FirstOrDefaultAsync(a => a.email.Equals(email));
            return currentMentor.mentorId;
        }

        //create new mentor
        [HttpPost("/mentor/new")]
        public async Task<IActionResult> NewMentee(UserRegDTO newMr)
        {
            try
            {
                var mentor = new mentor
                {
                    firstName = newMr.firstName,
                    lastName = newMr.lastName,
                    email = newMr.email

                };
                var login = new login
                {
                    email = newMr.email,
                    password = newMr.password,
                    role = newMr.role
                };
                _context.Mentors.Add(mentor);
                _context.Logins.Add(login);
                await _context.SaveChangesAsync();
                return Ok(newMr.email);
            }
            catch
            {
                return BadRequest("Sign up has failed.");
            }
        }


        //get all mentorships by mentorid
        [HttpGet("/mentorships")]
        public async Task<List<mentorship>> GetAllByID (int id)
        {
            var mentorships = await _context.Mentorships.Where(x => x.mentorId == id).ToListAsync();
            return mentorships;
        }

        //create new mentorship 
        [HttpPost("/mentorships/new")]
        public async Task<IActionResult> NewMentorship(mentorshipDTO newMs)
        {
            try
            {
                var mentorship = new mentorship
                {
                    mentorId = newMs.mentorId,
                    menteeId = newMs.menteeId
                };
                
                _context.Mentorships.Add(mentorship);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest("Sign up has failed.");
            }
        }

        //get images by mentorship id
        [HttpGet("/images/mentorshipid")]
        public async Task<IEnumerable<image>> GetIByMs(int mentorshipId)
        {
            return await _context.Images.Where(x => x.mentorshipId == mentorshipId).ToListAsync();

        }
    }
}
