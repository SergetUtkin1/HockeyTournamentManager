﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.Players
{
    public class EditModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public EditModel(DAL.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Player Player { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player =  await _context.Players.FirstOrDefaultAsync(m => m.PlayerId == id);
            if (player == null)
            {
                return NotFound();
            }
            Player = player;
           ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "Name");
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

            _context.Attach(Player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(Player.PlayerId))
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

        private bool PlayerExists(Guid id)
        {
          return (_context.Players?.Any(e => e.PlayerId == id)).GetValueOrDefault();
        }
    }
}
