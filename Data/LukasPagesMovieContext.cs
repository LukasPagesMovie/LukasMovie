using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LukasPagesMovie.Models;

namespace LukasPagesMovie.Models
{
    public class LukasPagesMovieContext : DbContext
    {
        public LukasPagesMovieContext (DbContextOptions<LukasPagesMovieContext> options)
            : base(options)
        {
        }

        public DbSet<LukasPagesMovie.Models.Movie> Movie { get; set; }

        public DbSet<LukasPagesMovie.Models.Series> Series { get; set; }
    }
}
