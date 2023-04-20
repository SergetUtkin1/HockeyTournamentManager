using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.MatchStatistics
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public DeleteModel(DAL.DataContext context)
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

            var matchstatistic = await _context.MatchStatistics.FirstOrDefaultAsync(m => m.MatchStatisticId == id);

            if (matchstatistic == null)
            {
                return NotFound();
            }
            else 
            {
                MatchStatistic = matchstatistic;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.MatchStatistics == null)
            {
                return NotFound();
            }
            var matchstatistic = await _context.MatchStatistics.FindAsync(id);

            if (matchstatistic != null)
            {
                MatchStatistic = matchstatistic;
                _context.MatchStatistics.Remove(MatchStatistic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
