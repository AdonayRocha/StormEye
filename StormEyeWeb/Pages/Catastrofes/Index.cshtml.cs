using Microsoft.AspNetCore.Mvc.RazorPages;
using StormEyeApi.Models;
using StormEyeApi.Data;
using Microsoft.EntityFrameworkCore;

namespace StormEyeWeb.Pages.Catastrofes
{
    public class IndexModel : PageModel
    {
        private readonly StormEyeContext _context;

        public IndexModel(StormEyeContext context)
        {
            _context = context;
        }

        public IList<CatastrofeMapeada> Catastrofes { get; set; }

        public async Task OnGetAsync()
        {
            Catastrofes = await _context.Catastrofes.ToListAsync();
        }
    }
}
