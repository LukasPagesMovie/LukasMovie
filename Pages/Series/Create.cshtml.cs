using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LukasPagesMovie.Models;

namespace LukasPagesMovie.Pages.Series
{
    public class CreateModel : PageModel
    {
        private readonly LukasPagesMovie.Models.LukasPagesMovieContext _context;

        public CreateModel(LukasPagesMovie.Models.LukasPagesMovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LukasPagesMovie.Models.Series Series { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Series.Add(Series);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}