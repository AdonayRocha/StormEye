using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StormEyeApi.Data;
using StormEyeApi.Models;

namespace StormEyeWeb.Pages.Cartilhas
{
    public class CreateModel : PageModel
    {
        private readonly StormEyeContext _context;

        public CreateModel(StormEyeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CartilhaMapeada Cartilha { get; set; }

        public SelectList Catastrofes { get; set; }

        public void OnGet()
        {
            Catastrofes = new SelectList(_context.Catastrofes, "IdCatastrofeM", "NomeCatastrofeM");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Catastrofes = new SelectList(_context.Catastrofes, "IdCatastrofeM", "NomeCatastrofeM");
                return Page();
            }

            _context.Cartilhas.Add(Cartilha);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
