using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LukasPagesMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;



namespace LukasPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly LukasPagesMovie.Models.LukasPagesMovieContext _context;

        public IndexModel(LukasPagesMovie.Models.LukasPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        
        public async Task OnGetAsync()
        {

            var client = new HttpClient();
           
            HttpResponseMessage response = await client.GetAsync("https://localhost:44349/api/Movies");
            if (response.IsSuccessStatusCode)
            {
                Movie = await response.Content.ReadAsAsync<List<Movie>>();
            }
          
        }

    }

}
