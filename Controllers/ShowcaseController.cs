using ArtisoraServer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtisoraServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShowcaseController : Controller
    {
        private readonly ApplicationDBContext _context;
        public ShowcaseController(ApplicationDBContext context)
        {
            this._context = context;
        }

        //get showcases by mentorId
        [HttpGet("/showcases")]
        public async Task<List<showcase>> GetShowcaseByID (int id){
            var showcase = await _context.Showcases.Where(x => x.mentorId == id).ToListAsync();
            return showcase;
        }

        [HttpGet("/showcases/new")]
        public async Task<IActionResult> NewShowcase(ShowcaseDTO newSc)
        {
            try
            {
                var showcase = new showcase
                {
                  image1 = newSc.image1,
                  image2 = newSc.image2,
                  image3 = newSc.image3,
                  image1Caption = newSc.image1Caption,
                  image2Caption = newSc.image2Caption,
                  image3Caption = newSc.image3Caption
                };
                _context.Showcases.Add(showcase);
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
