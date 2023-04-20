using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.Penalties
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public DeleteModel(DAL.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Penalties == null)
            {
                return NotFound();
            }
            var penalty = await _context.Penalties.FindAsync(id);

            if (penalty != null)
            {
                Penalty = penalty;
                _context.Penalties.Remove(Penalty);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
