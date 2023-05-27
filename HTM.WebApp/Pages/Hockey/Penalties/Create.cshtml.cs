using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.Penalties
{
    public class CreateModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public CreateModel(DAL.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Penalty Penalty { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Penalties == null || Penalty == null)
            {
                return Page();
            }

            _context.Penalties.Add(Penalty);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
