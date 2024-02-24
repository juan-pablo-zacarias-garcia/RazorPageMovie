using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;
using System.ComponentModel.DataAnnotations;

namespace RazorPageMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPageMovieContext(serviceProvider.GetRequiredService<DbContextOptions<RazorPageMovieContext>>()))
            {
                if(context == null || context.Movie==null)
                {
                    throw new ArgumentException("NullRazorPagesMovieContext");
                }
                //Para mirar cualquier película
                if (context.Movie.Any())
                {
                    return;//Db muestra todo lo que contiene la clase
                }
                context.Movie.AddRange(new Movie
                {
                    Title="When I met your mother",
                    ReleaseDate=DateTime.Parse("1989-01-25"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = "R"

                },
                new Movie
                {
                    Title = "Ghost Busters",
                    ReleaseDate = DateTime.Parse("1984-03-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "G"
                },
                new Movie
                {
                    Title = "Forest Gump",
                    ReleaseDate = DateTime.Parse("2000-06-25"),
                    Genre = "Comedy",
                    Price = 6.78M,
                    Rating = "G"
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-04-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rating = "NA"
                }
                );

                context.SaveChanges();
            }
        }
        
    }
}
