using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.MatchStatistics
{
    public class IndexModel : PageModel
    {
        private readonly DAL.DataContext _context;

        public IndexModel(DAL.DataContext context)
        {
            _context = context;
        }

        public IList<MatchStatistic> MatchStatistic { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MatchStatistics != null)
            {
                MatchStatistic = await _context.MatchStatistics.ToListAsync();
            }
        }
    }
}
