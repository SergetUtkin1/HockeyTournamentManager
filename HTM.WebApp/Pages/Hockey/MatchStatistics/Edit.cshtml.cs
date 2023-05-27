using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.MatchStatistics
{
    public class EditModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public EditModel(DAL.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MatchStatistic MatchStatistic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.MatchStatistics == null)
            {
                return NotFound();
            }

            var matchstatistic =  await _context.MatchStatistics.FirstOrDefaultAsync(m => m.MatchStatisticId == id);
            if (matchstatistic == null)
            {
                return NotFound();
            }
            MatchStatistic = matchstatistic;
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

            _context.Attach(MatchStatistic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchStatisticExists(MatchStatistic.MatchStatisticId))
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

        private bool MatchStatisticExists(Guid id)
        {
          return (_context.MatchStatistics?.Any(e => e.MatchStatisticId == id)).GetValueOrDefault();
        }
    }
}
