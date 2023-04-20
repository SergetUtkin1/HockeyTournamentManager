using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.TeamStatistics
{
    public class CreateModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public CreateModel(DAL.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TeamStatistic TeamStatistic { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TeamStatistics == null || TeamStatistic == null)
            {
                return Page();
            }

            _context.TeamStatistics.Add(TeamStatistic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
