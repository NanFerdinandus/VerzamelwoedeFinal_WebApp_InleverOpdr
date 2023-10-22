using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_TestApp_W3_InlvrOpdr.Models;

namespace VerzamelWoedeAPI.Controllers
{
    [Route("api/postzegels")]
    [ApiController]
    public class PostzegelsAPIController : ControllerBase
    {
        private readonly AppDBContext _context;

        public PostzegelsAPIController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/postzegels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Postzegel>>> GetPostzegels()
        {
            var postzegels = await _context.Postzegels.Include(p => p.Eigenaar).ToListAsync();
            return postzegels;
        }

        // GET: api/postzegels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Postzegel>> GetPostzegel(int id)
        {
            var postzegel = await _context.Postzegels.Include(p => p.Eigenaar).FirstOrDefaultAsync(m => m.Id == id);

            if (postzegel == null)
            {
                return NotFound();
            }

            return postzegel;
        }

        // POST: api/postzegels
        [HttpPost]
        public async Task<IActionResult> PostPostzegel(Postzegel postzegel)
        {
            _context.Postzegels.Add(postzegel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostzegel", new { id = postzegel.Id }, postzegel);
        }

        // PUT: api/postzegels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostzegel(int id, Postzegel postzegel)
        {
            if (id != postzegel.Id)
            {
                return BadRequest();
            }

            _context.Entry(postzegel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostzegelExists(id))
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

        // DELETE: api/postzegels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostzegel(int id)
        {
            var postzegel = await _context.Postzegels.FindAsync(id);
            if (postzegel == null)
            {
                return NotFound();
            }

            _context.Postzegels.Remove(postzegel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostzegelExists(int id)
        {
            return (_context.Postzegels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
