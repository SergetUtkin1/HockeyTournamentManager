using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.Penalties
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public DetailsModel(DAL.DataContext context)
        {
            _context = context;
        }

      public Penalty Penalty { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Penalties == null)
            {
                return NotFound();
            }

            var penalty = await _context.Penalties.FirstOrDefaultAsync(m => m.PenaltyId == id);
            if (penalty == null)
            {
                return NotFound();
            }
            else 
            {
                Penalty = penalty;
            }
            return Page();
        }
    }
}
