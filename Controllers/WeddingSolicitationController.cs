using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoPortofolio.Models;

namespace PhotoPortofolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeddingSolicitationController : ControllerBase
    {
        private readonly Context _context;

        public WeddingSolicitationController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeddingSolicitation>>> GetWeddingSolicitation()
        {
            if (_context.WeddingSolicitations == null)
            {
                return NotFound();
            }

            return await _context.WeddingSolicitations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WeddingSolicitation>> GetWeddingSolicitation(int id)
        {
            if (_context.WeddingSolicitations == null)
            {
                return NotFound();
            }

            var weddingSolicitation = await _context.WeddingSolicitations.FindAsync(id);

            if (weddingSolicitation == null)
            {
                return NotFound();
            }

            return weddingSolicitation;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeddingSolicitation(int id, WeddingSolicitation weddingSolicitation)
        {
            if (id != weddingSolicitation.Id)
            {
                return BadRequest();
            }

            _context.Entry(weddingSolicitation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeddingSolicitationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<WeddingSolicitation>> PostWeddingSolicitation(
            WeddingSolicitation weddingSolicitation)
        {
            _context.WeddingSolicitations.Add(weddingSolicitation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeddingSolicitation", new { id = weddingSolicitation.Id }, weddingSolicitation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeddingSolicitation(int id)
        {
            if (_context.WeddingSolicitations == null)
            {
                return NotFound();
            }

            var weddingSolicitation = await _context.WeddingSolicitations.FindAsync(id);
            if (weddingSolicitation == null)
            {
                return NotFound();
            }

            _context.WeddingSolicitations.Remove(weddingSolicitation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeddingSolicitationExists(int id)
        {
            return (_context.WeddingSolicitations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}