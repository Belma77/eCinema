using eCInema.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Data.DataSeeder
{
    public class SeedMoviesProducersData
    {
        public static void SeedMoviesProducers(ModelBuilder builder)
        {
            builder.Entity<ProducerMovies>().HasData(
                new ProducerMovies() { MovieId = 1, ProducerId = 1 },
                new ProducerMovies() { MovieId = 2, ProducerId = 2 },
                new ProducerMovies() { MovieId = 3, ProducerId = 3 },
                new ProducerMovies() { MovieId = 4, ProducerId = 4 },
                new ProducerMovies() { MovieId = 5, ProducerId = 5 },
                new ProducerMovies() { MovieId = 6, ProducerId = 6 },
                new ProducerMovies() { MovieId = 7, ProducerId = 7 },
                new ProducerMovies() { MovieId = 8, ProducerId = 8 },
                new ProducerMovies() { MovieId = 9, ProducerId = 9 },
                new ProducerMovies() { MovieId = 10, ProducerId = 10 },
                new ProducerMovies() { MovieId = 11, ProducerId = 11 },
                new ProducerMovies() { MovieId = 12, ProducerId = 12 },
                new ProducerMovies() { MovieId = 13, ProducerId = 13 },
                new ProducerMovies() { MovieId = 14, ProducerId = 14 },
                new ProducerMovies() { MovieId = 15, ProducerId = 15 },
                new ProducerMovies() { MovieId = 16, ProducerId = 16 },
                new ProducerMovies() { MovieId = 17, ProducerId = 17 },
                new ProducerMovies() { MovieId = 18, ProducerId = 18 },
                new ProducerMovies() { MovieId = 19, ProducerId = 19 },
                new ProducerMovies() { MovieId = 20, ProducerId = 20},
                new ProducerMovies() { MovieId = 21, ProducerId = 21 },
                new ProducerMovies() { MovieId = 22, ProducerId = 22 },
                new ProducerMovies() { MovieId = 23, ProducerId = 23 }
                );

        }
    }
}
