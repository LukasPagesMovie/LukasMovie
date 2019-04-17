using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LukasPagesMovie.Models
{
    public class SeedData
    {

            public static void Initialize(IServiceProvider serviceProvider)
            {
                using (var context = new LukasPagesMovieContext(
                    serviceProvider.GetRequiredService<
                        DbContextOptions<LukasPagesMovieContext>>()))
                {
                    // Look for any movies.
                    if (context.Movie.Any())
                    {
                        return;   // DB has been seeded
                    }

                    context.Movie.AddRange(
                        new Movie
                        {
                            Title = "Avengers: Endgame",
                            ReleaseDate = DateTime.Parse("2019-4-25"),
                            Genre = "Fantasy",

                        },

                        new Movie
                        {
                            Title = "Captain Marvel ",
                            ReleaseDate = DateTime.Parse("2019-1-1"),
                            Genre = "Adventure",

                        },

                        new Movie
                        {
                            Title = "Us",
                            ReleaseDate = DateTime.Parse("2019-5-15"),
                            Genre = "Comedy",
 
                        },

                        new Movie
                        {
                            Title = "Leaving Neverland",
                            ReleaseDate = DateTime.Parse("2019-2-12"),
                            Genre = "Biography",

                        }
                    );
                    context.SaveChanges();
                }
            }


        }
    }
