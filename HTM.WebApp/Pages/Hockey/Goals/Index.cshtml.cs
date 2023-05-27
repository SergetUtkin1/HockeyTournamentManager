using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.Goals
{
    public class IndexModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public IndexModel(DAL.DataContext context)
        {
            _context = context;
        }

        public IList<Goal> Goal { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Goals != null)
            {
                Goal = await _context.Goals.ToListAsync();
            }
        }
    }
}
