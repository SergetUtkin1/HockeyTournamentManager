using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.TeamStatistics
{
    public class EditModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public EditModel(DAL.DataContext context)
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

            var teamstatistic =  await _context.TeamStatistics.FirstOrDefaultAsync(m => m.TeamStatisticId == id);
            if (teamstatistic == null)
            {
                return NotFound();
            }
            TeamStatistic = teamstatistic;
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

            _context.Attach(TeamStatistic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamStatisticExists(TeamStatistic.TeamStatisticId))
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

        private bool TeamStatisticExists(Guid id)
        {
          return (_context.TeamStatistics?.Any(e => e.TeamStatisticId == id)).GetValueOrDefault();
        }
    }
}
