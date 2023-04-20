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

namespace HTM.WebApp.Pages.Hockey.Goals
{
    public class EditModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public EditModel(DAL.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Goal Goal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Goals == null)
            {
                return NotFound();
            }

            var goal =  await _context.Goals.FirstOrDefaultAsync(m => m.GoalId == id);
            if (goal == null)
            {
                return NotFound();
            }
            Goal = goal;
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

            _context.Attach(Goal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalExists(Goal.GoalId))
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

        private bool GoalExists(Guid id)
        {
          return (_context.Goals?.Any(e => e.GoalId == id)).GetValueOrDefault();
        }
    }
}
