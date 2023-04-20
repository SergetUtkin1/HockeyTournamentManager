using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.TeamStatistics
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public DeleteModel(DAL.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TeamStatistic TeamStatistic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.TeamStatistics == null)
            {
                return NotFound();
            }

            var teamstatistic = await _context.TeamStatistics.FirstOrDefaultAsync(m => m.TeamStatisticId == id);

            if (teamstatistic == null)
            {
                return NotFound();
            }
            else 
            {
                TeamStatistic = teamstatistic;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.TeamStatistics == null)
            {
                return NotFound();
            }
            var teamstatistic = await _context.TeamStatistics.FindAsync(id);

            if (teamstatistic != null)
            {
                TeamStatistic = teamstatistic;
                _context.TeamStatistics.Remove(TeamStatistic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
