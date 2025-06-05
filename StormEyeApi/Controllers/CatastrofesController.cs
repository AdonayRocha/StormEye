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
    public class CatastrofesController : ControllerBase
    {
        private readonly StormEyeContext _context;

        public CatastrofesController(StormEyeContext context)
        {
            _context = context;
        }

        // GET: api/Catastrofes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catastrofe>>> GetAll()
        {
            var catastrofes = await _context.Catastrofes
                .Include(c => c.CatastrofeCartilhas)
                    .ThenInclude(cc => cc.Cartilha)
                .ToListAsync();

            return Ok(catastrofes);
        }

        // GET: api/Catastrofes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Catastrofe>> GetById(int id)
        {
            var cat = await _context.Catastrofes
                .Include(c => c.CatastrofeCartilhas)
                    .ThenInclude(cc => cc.Cartilha)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cat == null)
                return NotFound();

            return Ok(cat);
        }

        // POST: api/Catastrofes
        [HttpPost]
        public async Task<ActionResult<Catastrofe>> Create([FromBody] Catastrofe payload)
        {
            _context.Catastrofes.Add(payload);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = payload.Id }, payload);
        }

        // PUT ou PATCH podem ser adicionados aqui se quiser editar uma Catastrofe

        // DELETE: api/Catastrofes/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _context.Catastrofes.FindAsync(id);
            if (cat == null) return NotFound();

            _context.Catastrofes.Remove(cat);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Catastrofes/{catId}/cartilhas/{cartId}
        // Associa uma Cartilha a esta Catastrofe
        [HttpPost("{catId:int}/cartilhas/{cartId:int}")]
        public async Task<IActionResult> LinkCartilha(int catId, int cartId)
        {
            var exists = await _context.CatastrofeCartilhas.FindAsync(catId, cartId);
            if (exists != null)
                return BadRequest("Essa associação já existe.");

            // Para garantir que ambos existam
            var cat = await _context.Catastrofes.FindAsync(catId);
            var cart = await _context.Cartilhas.FindAsync(cartId);
            if (cat == null || cart == null)
                return NotFound("Catastrofe ou Cartilha não encontrado.");

            _context.CatastrofeCartilhas.Add(
                new CatastrofeCartilha { CatastrofeId = catId, CartilhaId = cartId }
            );
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Catastrofes/{catId}/cartilhas/{cartId}
        // Desassocia uma Cartilha desta Catastrofe
        [HttpDelete("{catId:int}/cartilhas/{cartId:int}")]
        public async Task<IActionResult> UnlinkCartilha(int catId, int cartId)
        {
            var link = await _context.CatastrofeCartilhas.FindAsync(catId, cartId);
            if (link == null)
                return NotFound();

            _context.CatastrofeCartilhas.Remove(link);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
