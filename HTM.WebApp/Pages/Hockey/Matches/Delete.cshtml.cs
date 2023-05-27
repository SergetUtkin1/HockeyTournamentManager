using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.Matches
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public DeleteModel(DAL.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Match Match { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Matches == null)
            {
                return NotFound();
            }

            var match = await _context.Matches.FirstOrDefaultAsync(m => m.MatchId == id);

            if (match == null)
            {
                return NotFound();
            }
            else 
            {
                Match = match;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Matches == null)
            {
                return NotFound();
            }
            var match = await _context.Matches.FindAsync(id);

            if (match != null)
            {
                Match = match;
                _context.Matches.Remove(Match);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
