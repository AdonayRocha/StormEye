using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StormEye.Domain.Entities;
using StormEye.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class CatastrofesController : ControllerBase
    {
        private readonly StormEyeContext _context;

        public CatastrofesController(StormEyeContext context)
        {
            _context = context;
        }

        // GET: api/Catastrofes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatastrofeMapeada>>> GetAll()
        {
            // Incluir as Cartilhas vinculadas a cada Catastrofe
            var catastrofes = await _context.Catastrofes
                .Include(c => c.Cartilhas)
                .ToListAsync();
            return Ok(catastrofes);
        }

        // GET: api/Catastrofes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CatastrofeMapeada>> GetById(int id)
        {
            var cat = await _context.Catastrofes
                .Include(c => c.Cartilhas)
                .FirstOrDefaultAsync(c => c.IdCatastrofeM == id);

            if (cat == null) return NotFound();
            return Ok(cat);
        }

        // POST: api/Catastrofes
        [HttpPost]
        public async Task<ActionResult<CatastrofeMapeada>> Create([FromBody] CatastrofeMapeada payload)
        {
            _context.Catastrofes.Add(payload);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = payload.IdCatastrofeM }, payload);
        }

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
        // Associa uma Cartilha existente a esta Catastrofe
        [HttpPost("{catId:int}/cartilhas/{cartId:int}")]
        public async Task<IActionResult> LinkCartilha(int catId, int cartId)
        {
            var cat = await _context.Catastrofes.FindAsync(catId);
            var cart = await _context.Cartilhas.FindAsync(cartId);

            if (cat == null || cart == null) return NotFound("Catastrofe ou Cartilha não encontrado.");

            // Se já estiver associado, retorna BadRequest
            if (cart.IdCatastrofeM == catId)
            {
                return BadRequest("Esta Cartilha já está vinculada a essa Catastrofe.");
            }

            cart.IdCatastrofeM = catId;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Catastrofes/{catId}/cartilhas/{cartId}
        // Desassocia a Cartilha dessa Catastrofe (seta FK para null ou remove registro?)
        [HttpDelete("{catId:int}/cartilhas/{cartId:int}")]
        public async Task<IActionResult> UnlinkCartilha(int catId, int cartId)
        {
            var cart = await _context.Cartilhas.FindAsync(cartId);

            if (cart == null || cart.IdCatastrofeM != catId)
                return NotFound();

            // Para “desassociar” basta definir a FK como 0 ou null – 
            // mas como no nosso modelo a FK é int (não-nullable), vou colocar 0 e depois você decide se quer apagar a cartilha ou obrigar reatribuição.
            cart.IdCatastrofeM = 0;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
