using eCInema.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Data.DataSeeder
{
    public class SeedMoviesGenresData
    {
        public static void SeedMoviesGenres(ModelBuilder builder)
        {
            builder.Entity<MoviesGenres>().HasData(
                new MoviesGenres() { MovieId = 1, GenreId = 1 },
                new MoviesGenres() { MovieId = 1, GenreId = 2 },
                new MoviesGenres() { MovieId = 1, GenreId = 3 },
                new MoviesGenres() { MovieId = 2, GenreId = 1 },
                new MoviesGenres() { MovieId = 2, GenreId = 5 },
                new MoviesGenres() { MovieId = 3, GenreId = 1 },
                new MoviesGenres() { MovieId = 4, GenreId = 11 },
                new MoviesGenres() { MovieId = 5, GenreId = 2 },
                new MoviesGenres() { MovieId = 5, GenreId = 15 },
                new MoviesGenres() { MovieId = 6, GenreId = 2 },
                new MoviesGenres() { MovieId = 6, GenreId = 11 },
                new MoviesGenres() { MovieId = 7, GenreId = 11 },
                new MoviesGenres() { MovieId = 8, GenreId = 9 },
                new MoviesGenres() { MovieId = 8, GenreId = 11 },
                new MoviesGenres() { MovieId = 9, GenreId = 1 },
                new MoviesGenres() { MovieId = 9, GenreId = 5 },
                new MoviesGenres() { MovieId = 10, GenreId = 1 },
                new MoviesGenres() { MovieId = 10, GenreId = 5 },
                new MoviesGenres() { MovieId = 10, GenreId = 6 },
                new MoviesGenres() { MovieId = 11, GenreId = 1 },
                new MoviesGenres() { MovieId = 11, GenreId = 5 },
                new MoviesGenres() { MovieId = 12, GenreId =11 },
                new MoviesGenres() { MovieId = 13, GenreId = 11 },
                new MoviesGenres() { MovieId = 14, GenreId = 11 },
                new MoviesGenres() { MovieId = 15, GenreId = 4},
                new MoviesGenres() { MovieId = 16, GenreId = 4 },
                new MoviesGenres() { MovieId = 16, GenreId = 7 },
                new MoviesGenres() { MovieId = 17, GenreId = 8},
                new MoviesGenres() { MovieId = 18, GenreId = 1 },
                new MoviesGenres() { MovieId = 18, GenreId = 5 },
                new MoviesGenres() { MovieId = 18, GenreId = 6 },
                new MoviesGenres() { MovieId = 19, GenreId = 2 },
                new MoviesGenres() { MovieId = 19, GenreId = 15 },
                new MoviesGenres() { MovieId = 20, GenreId = 2 },
                new MoviesGenres() { MovieId = 21, GenreId = 16 },
                new MoviesGenres() { MovieId = 21, GenreId = 5 },
                new MoviesGenres() { MovieId = 22, GenreId = 16 },
                new MoviesGenres() { MovieId = 22, GenreId = 5 },
                new MoviesGenres() { MovieId = 23, GenreId = 2 },
                new MoviesGenres() { MovieId = 23, GenreId =11 }
            );
        }
    }
}
