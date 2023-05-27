using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.Infractions
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public DetailsModel(DAL.DataContext context)
        {
            _context = context;
        }

      public Infraction Infraction { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Infractions == null)
            {
                return NotFound();
            }

            var infraction = await _context.Infractions.FirstOrDefaultAsync(m => m.InfractionId == id);
            if (infraction == null)
            {
                return NotFound();
            }
            else 
            {
                Infraction = infraction;
            }
            return Page();
        }
    }
}
