using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.Penalties
{
    public class EditModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public EditModel(DAL.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Penalty Penalty { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Penalties == null)
            {
                return NotFound();
            }

            var penalty =  await _context.Penalties.FirstOrDefaultAsync(m => m.PenaltyId == id);
            if (penalty == null)
            {
                return NotFound();
            }
            Penalty = penalty;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Penalty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PenaltyExists(Penalty.PenaltyId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PenaltyExists(Guid id)
        {
          return (_context.Penalties?.Any(e => e.PenaltyId == id)).GetValueOrDefault();
        }
    }
}
