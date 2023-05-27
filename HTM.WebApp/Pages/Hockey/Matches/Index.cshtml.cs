using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.Matches
{
    public class IndexModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public IndexModel(DAL.DataContext context)
        {
            _context = context;
        }

        public IList<Match> Match { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Matches != null)
            {
                Match = await _context.Matches
                .Include(m => m.FirstTeam)
                .Include(m => m.SecondTeam).ToListAsync();
            }
        }
    }
}
