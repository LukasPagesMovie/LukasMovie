using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LukasPagesMovie.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LukasPagesMovie.Pages.Movies
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
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            //var client = new HttpClient();
            //HttpResponseMessage response = await client.PostAsJsonAsync(
            //"https://localhost:44349/api/Movies/Create", Movie);
            //response.EnsureSuccessStatusCode();
            //// Movie = await response.Content.ReadAsAsync<Movie>();


            //return RedirectToPage("./Index");

        }
    }
}