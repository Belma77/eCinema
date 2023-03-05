using eCInema.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Data.DataSeeder
{
    public class SeedDirectorsMoviesData
    {
        public static void SeedMoviesDirectors(ModelBuilder builder)
        {
            builder.Entity<DirectorsMovies>().HasData(
                new DirectorsMovies() { MovieId = 1, DirectorId = 1 },
                new DirectorsMovies() { MovieId = 2, DirectorId = 2 },
                new DirectorsMovies() { MovieId = 3, DirectorId = 3 },
                new DirectorsMovies() { MovieId = 4, DirectorId = 4 },
                new DirectorsMovies() { MovieId = 5, DirectorId = 5 },
                new DirectorsMovies() { MovieId = 6, DirectorId = 6 },
                new DirectorsMovies() { MovieId = 7, DirectorId = 7 },
                new DirectorsMovies() { MovieId = 8, DirectorId = 8 },
                new DirectorsMovies() { MovieId = 9, DirectorId = 9 },
                new DirectorsMovies() { MovieId = 10, DirectorId = 10 },
                new DirectorsMovies() { MovieId = 11, DirectorId = 11 },
                new DirectorsMovies() { MovieId = 12, DirectorId = 12 },
                new DirectorsMovies() { MovieId = 13, DirectorId = 13 },
                new DirectorsMovies() { MovieId = 14, DirectorId = 14 },
                new DirectorsMovies() { MovieId = 15, DirectorId = 15 },
                new DirectorsMovies() { MovieId = 16, DirectorId = 16 },
                new DirectorsMovies() { MovieId = 17, DirectorId = 17 },
                new DirectorsMovies() { MovieId = 18, DirectorId = 18 },
                new DirectorsMovies() { MovieId = 19, DirectorId = 19 },
                new DirectorsMovies() { MovieId = 20, DirectorId = 20 },
                new DirectorsMovies() { MovieId = 21, DirectorId = 21 },
                new DirectorsMovies() { MovieId = 22, DirectorId = 22 },
                new DirectorsMovies() { MovieId = 23, DirectorId = 1 }
                );
        }
    }
}
