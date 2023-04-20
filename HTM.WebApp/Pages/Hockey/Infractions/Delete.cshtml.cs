using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.Infractions
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public DeleteModel(DAL.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Infractions == null)
            {
                return NotFound();
            }
            var infraction = await _context.Infractions.FindAsync(id);

            if (infraction != null)
            {
                Infraction = infraction;
                _context.Infractions.Remove(Infraction);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
