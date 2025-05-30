using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StormEyeApi.Data;
using StormEyeApi.Models;

namespace StormEyeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatastrofeMapeadaController : ControllerBase
    {
        private readonly StormEyeContext _context;

        public CatastrofeMapeadaController(StormEyeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatastrofeMapeada>>> GetAll()
        {
            return await _context.Catastrofes.Include(c => c.Cartilhas).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CatastrofeMapeada>> GetById(int id)
        {
            var catastrofe = await _context.Catastrofes
                .Include(c => c.Cartilhas)
                .FirstOrDefaultAsync(c => c.IdCatastrofeM == id);

            return catastrofe == null ? NotFound() : Ok(catastrofe);
        }

        [HttpPost]
        public async Task<ActionResult<CatastrofeMapeada>> Create(CatastrofeMapeada catastrofe)
        {
            _context.Catastrofes.Add(catastrofe);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = catastrofe.IdCatastrofeM }, catastrofe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CatastrofeMapeada model)
        {
            if (id != model.IdCatastrofeM) return BadRequest();

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Catastrofes.FindAsync(id);
            if (item == null) return NotFound();

            _context.Catastrofes.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
