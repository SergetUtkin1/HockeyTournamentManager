using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.MatchStatistics
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public DetailsModel(DAL.DataContext context)
        {
            _context = context;
        }

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
    }
}
