using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LukasPagesMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LukasPagesMovie.Pages.Series
{
    public class IndexModel : PageModel
    {
        private readonly LukasPagesMovie.Models.LukasPagesMovieContext _context;

        public IndexModel(LukasPagesMovie.Models.LukasPagesMovieContext context)
        {
            _context = context;
        }

        public IList<LukasPagesMovie.Models.Series> Series { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SeriesGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Series
                                            orderby m.Genre
                                            select m.Genre;

            var series = from m in _context.Series
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                series = series.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(SeriesGenre))
            {
                series = series.Where(x => x.Genre == SeriesGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Series = await series.ToListAsync();
        }
    }
}
