using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StormEye.Domain.Entities;
using StormEye.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StormEye.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartilhasController : ControllerBase
    {
        private readonly StormEyeContext _context;

        public CartilhasController(StormEyeContext context)
        {
            _context = context;
        }

        // GET: api/Cartilhas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cartilha>>> GetAll()
        {
            var cartilhas = await _context.Cartilhas
                .Include(c => c.CatastrofeCartilhas)
                    .ThenInclude(cc => cc.Catastrofe)
                .ToListAsync();

            return Ok(cartilhas);
        }

        // GET: api/Cartilhas/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cartilha>> GetById(int id)
        {
            var cart = await _context.Cartilhas
                .Include(c => c.CatastrofeCartilhas)
                    .ThenInclude(cc => cc.Catastrofe)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cart == null)
                return NotFound();

            return Ok(cart);
        }

        // POST: api/Cartilhas
        [HttpPost]
        public async Task<ActionResult<Cartilha>> Create([FromBody] Cartilha payload)
        {
            _context.Cartilhas.Add(payload);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = payload.Id }, payload);
        }

        // PUT ou PATCH podem ser adicionados se quiser editar uma Cartilha

        // DELETE: api/Cartilhas/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cart = await _context.Cartilhas.FindAsync(id);
            if (cart == null) return NotFound();

            _context.Cartilhas.Remove(cart);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
