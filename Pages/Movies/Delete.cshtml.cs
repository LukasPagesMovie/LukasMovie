using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LukasPagesMovie.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LukasPagesMovie.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly LukasPagesMovie.Models.LukasPagesMovieContext _context;

        public DeleteModel(LukasPagesMovie.Models.LukasPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //Movie = await _context.Movie.FindAsync(id);

            //if (Movie != null)
            //{
            //    _context.Movie.Remove(Movie);
            //    await _context.SaveChangesAsync();
            //}
            var client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(
        $"https://localhost:44349/api/Movies/{id}");
            

            return RedirectToPage("./Index");
        }
    }
}
