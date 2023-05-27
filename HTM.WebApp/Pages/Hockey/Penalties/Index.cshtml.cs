using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.Penalties
{
    public class IndexModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public IndexModel(DAL.DataContext context)
        {
            _context = context;
        }

        public IList<Penalty> Penalty { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Penalties != null)
            {
                Penalty = await _context.Penalties.ToListAsync();
            }
        }
    }
}
