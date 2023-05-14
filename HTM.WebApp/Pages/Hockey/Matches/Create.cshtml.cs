using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.Matches
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
        ViewData["FirstTeamId"] = new SelectList(_context.Teams, "TeamId", "Name");
        ViewData["SecondTeamId"] = new SelectList(_context.Teams, "TeamId", "Name");
            return Page();
        }

        [BindProperty]
        public Match Match { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (_context.Matches == null || Match == null)
            {
                return Page();
            }


            Match.Date = Match.Date?.ToUniversalTime();
            _context.Matches.Add(Match);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
