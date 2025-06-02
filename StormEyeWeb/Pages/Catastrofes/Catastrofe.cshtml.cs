using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StormEyeApi.Models;
using StormEyeApi.Data;

namespace StormEyeWeb.Pages.Catastrofes
{
    public class CreateModel : PageModel
    {
        private readonly StormEyeContext _context;

        public CreateModel(StormEyeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CatastrofeMapeada Catastrofe { get; set; }

        public IActionResult OnGet() => Page();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Catastrofes.Add(Catastrofe);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
