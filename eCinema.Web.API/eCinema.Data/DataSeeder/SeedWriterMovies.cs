using eCInema.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Data.DataSeeder
{
    public class SeedWriterMovies
    {
        public static void SeedWritersMovies(ModelBuilder builder)
        {
            builder.Entity<WritersMovies>().HasData(
                new WritersMovies() { MovieId = 1, WriterId = 1 },
                new WritersMovies() { MovieId = 2, WriterId = 4 },
                new WritersMovies() { MovieId = 3, WriterId = 2 },
                new WritersMovies() { MovieId = 4, WriterId = 3 },
                new WritersMovies() { MovieId = 5, WriterId = 5},
                new WritersMovies() { MovieId = 6, WriterId = 6 },
                new WritersMovies() { MovieId = 7, WriterId = 7 },
                new WritersMovies() { MovieId = 8, WriterId = 8 },
                new WritersMovies() { MovieId = 9, WriterId = 9 },
                new WritersMovies() { MovieId = 10, WriterId = 10 },
                new WritersMovies() { MovieId = 11, WriterId = 11 },
                new WritersMovies() { MovieId = 12, WriterId = 12 },
                new WritersMovies() { MovieId = 13, WriterId = 13 },
                new WritersMovies() { MovieId = 14, WriterId = 14 },
                new WritersMovies() { MovieId = 15, WriterId = 15 },
                new WritersMovies() { MovieId = 16, WriterId = 16 },
                new WritersMovies() { MovieId = 17, WriterId = 17 },
                new WritersMovies() { MovieId = 18, WriterId = 18 },
                new WritersMovies() { MovieId = 19, WriterId = 19 },
                new WritersMovies() { MovieId = 20, WriterId = 20 },
                new WritersMovies() { MovieId = 21, WriterId = 21 },
                new WritersMovies() { MovieId = 22, WriterId = 22 },
                new WritersMovies() { MovieId = 23, WriterId = 23 }
               );
        }

    }
}
