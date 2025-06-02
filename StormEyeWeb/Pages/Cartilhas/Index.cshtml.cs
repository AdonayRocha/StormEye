using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StormEyeApi.Data;
using StormEyeApi.Models;

namespace StormEyeWeb.Pages.Cartilhas
{
    public class IndexModel : PageModel
    {
        private readonly StormEyeContext _context;

        public IndexModel(StormEyeContext context)
        {
            _context = context;
        }

        public IList<CartilhaMapeada> Cartilhas { get; set; }

        public async Task OnGetAsync()
        {
            Cartilhas = await _context.Cartilhas
                .Include(c => c.Catastrofe) 
                .ToListAsync();
        }

    }
}
