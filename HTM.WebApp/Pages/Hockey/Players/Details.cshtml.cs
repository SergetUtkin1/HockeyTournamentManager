﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.Players
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public DetailsModel(DAL.DataContext context)
        {
            _context = context;
        }

      public Player Player { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player = await _context.Players.Include(p => p.Team).FirstOrDefaultAsync(m => m.PlayerId == id);
            if (player == null)
            {
                return NotFound();
            }
            else 
            {
                Player = player;
            }
            return Page();
        }
    }
}
