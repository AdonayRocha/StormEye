using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StormEye.Domain.Entities;
using StormEye.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StormEye.Api.Controllers
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
        public async Task<ActionResult<IEnumerable<CartilhaMapeada>>> GetAll()
        {
            // Incluir info da Catastrofe a que pertence (se precisar)
            var cartilhas = await _context.Cartilhas
                .Include(c => c.Catastrofe)
                .ToListAsync();
            return Ok(cartilhas);
        }

        // GET: api/Cartilhas/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CartilhaMapeada>> GetById(int id)
        {
            var cart = await _context.Cartilhas
                .Include(c => c.Catastrofe)
                .FirstOrDefaultAsync(c => c.IdCartilhaM == id);

            if (cart == null) return NotFound();
            return Ok(cart);
        }

        // POST: api/Cartilhas
        [HttpPost]
        public async Task<ActionResult<CartilhaMapeada>> Create([FromBody] CartilhaMapeada payload)
        {
            _context.Cartilhas.Add(payload);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = payload.IdCartilhaM }, payload);
        }

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
