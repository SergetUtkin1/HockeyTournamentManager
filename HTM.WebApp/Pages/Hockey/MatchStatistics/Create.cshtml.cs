using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DAL.Entities;

namespace HTM.WebApp.Pages.Hockey.MatchStatistics
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
        public MatchStatistic MatchStatistic { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MatchStatistics == null || MatchStatistic == null)
            {
                return Page();
            }

            _context.MatchStatistics.Add(MatchStatistic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
