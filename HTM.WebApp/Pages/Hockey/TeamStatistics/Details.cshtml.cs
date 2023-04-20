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
    public class DetailsModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public DetailsModel(DAL.DataContext context)
        {
            _context = context;
        }

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
    }
}
