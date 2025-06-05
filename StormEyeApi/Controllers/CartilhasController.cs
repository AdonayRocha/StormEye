using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StormEyeApi.Data;
using StormEyeApi.Models;

namespace StormEyeApi.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartilhaViewModel>>> GetAll()
        {
            return await _context.Cartilhas.Include(c => c.Catastrofe).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartilhaViewModel>> GetById(int id)
        {
            var cartilha = await _context.Cartilhas
                .Include(c => c.Catastrofe)
                .FirstOrDefaultAsync(c => c.IdCartilhaM == id);

            return cartilha == null ? NotFound() : Ok(cartilha);
        }


        [HttpPost]
        public async Task<ActionResult<CartilhaViewModel>> Create(CartilhaViewModel cartilha)
        {
            _context.Cartilhas.Add(cartilha);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = cartilha.IdCartilhaM }, cartilha);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CartilhaViewModel model)
        {
            if (id != model.IdCartilhaM) return BadRequest();

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Cartilhas.FindAsync(id);
            if (item == null) return NotFound();

            _context.Cartilhas.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
