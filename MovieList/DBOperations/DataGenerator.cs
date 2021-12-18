using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieList.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.DBOperations
{
    public class DataGenerator
    {
        public static void Initalize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieListDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieListDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre
                    {
                        Name="Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Horror"
                    },
                    new Genre
                    {
                        Name = "Drama"
                    },
                    new Genre
                    {
                        Name = "Documentary"
                    },
                    new Genre
                    {
                        Name = "Animation"
                    }

                );
                context.Movies.AddRange(
                    new Movie
                    {
                        //Id = 1, id'lere artık gere yok, çünkü Movie.cs'de otomatik tanımlanıyor
                        Title = "I Lost My Body",
                        Year = 2019,
                        Director = "Jeremy Clapin",
                        GenreId = 4,
                        Language = "French",
                        Ratings = 7.6,
                        Released = new DateTime(2019, 06, 16)
                    },
                    new Movie
                    {
                        //Id = 2,
                        Title = "Capernaum",
                        Year = 2018,
                        Director = "Nadine Labaki",
                        GenreId =2,
                        Language = "Arabic",
                        Ratings = 8.4,
                        Released = new DateTime(2018, 03, 27)
                    },
                    new Movie
                    {
                        //Id = 3,
                        Title = "Oldboy",
                        Year = 2003,
                        Director = "Park Chan Wook",
                        GenreId = 2,
                        Language = "Korean",
                        Ratings = 8.5,
                        Released = new DateTime(2018, 03, 27)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
