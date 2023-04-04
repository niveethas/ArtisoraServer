
using ArtisoraServer.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtisoraServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MenteeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public MenteeController(ApplicationDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            this._context = context;
            _hostingEnvironment = webHostEnvironment;
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

        /// <summary>
        /// register a new new mentee
        /// </summary>
        //registering a new mentee
        [HttpPost("/mentee/new")]
        public async Task<IActionResult> NewMentee(UserRegDTO newM)
        {
            try
            {
                var mentee = new mentee
                {
                    firstName = newM.firstName,
                    lastName = newM.lastName,
                    email = newM.email

                };
                var login = new login
                {
                    email = newM.email,
                    password = newM.password,
                    role = newM.role
                };
                _context.Mentees.Add(mentee);
                _context.Logins.Add(login);
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
        
        //get mentorship id by mentee 
        [HttpGet("/mentorships/menteeid/id")]
        public async Task<int> GetMsIDByID(int id)
        {
            var currentMentorship = await _context.Mentorships.FirstAsync(x => x.menteeId == id);
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

        [HttpPost("/image/upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            try
            {
                //var pathName = Path.Combine(_hostingEnvironment.ContentRootPath, "Images");
                var pathName = "C:\\Users\\nivee\\Desktop\\FYP\\ArtisoraWebsite\\wwwroot\\WorkImages\\";
                string filePath = Path.Combine(pathName, file.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }
                
                return StatusCode(200, file.FileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }

    
}
