using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LukasPagesMovie.Models;

namespace LukasPagesMovie.Pages.Series
{
    public class DetailsModel : PageModel
    {
        private readonly LukasPagesMovie.Models.LukasPagesMovieContext _context;

        public DetailsModel(LukasPagesMovie.Models.LukasPagesMovieContext context)
        {
            _context = context;
        }

        public LukasPagesMovie.Models.Series Series { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Series = await _context.Series.FirstOrDefaultAsync(m => m.ID == id);

            if (Series == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
