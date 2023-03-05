using eCInema.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Data.DataSeeder
{
    public class SeedMoviesActorsData
    {
        public static void SeedMoviesActors(ModelBuilder builder)
        {
            builder.Entity<ActorsMovies>().HasData(
             new ActorsMovies() { MovieId = 1, ActorId = 1 },
             new ActorsMovies() { MovieId = 2, ActorId = 4 },
             new ActorsMovies() { MovieId = 2, ActorId = 34 },
             new ActorsMovies() { MovieId = 3, ActorId = 2 },
             new ActorsMovies() { MovieId = 3, ActorId = 3 },
             new ActorsMovies() { MovieId = 4, ActorId = 5 },
             new ActorsMovies() { MovieId = 4, ActorId = 6 },
             new ActorsMovies() { MovieId = 5, ActorId = 7 },
             new ActorsMovies() { MovieId = 5, ActorId = 8 },
             new ActorsMovies() { MovieId = 6, ActorId = 9 },
             new ActorsMovies() { MovieId = 6, ActorId = 10 },
             new ActorsMovies() { MovieId = 7, ActorId = 11 },
             new ActorsMovies() { MovieId = 7, ActorId = 12 },
             new ActorsMovies() { MovieId = 8, ActorId = 13 },
             new ActorsMovies() { MovieId = 8, ActorId = 14 },
             new ActorsMovies() { MovieId = 9, ActorId = 15 },
             new ActorsMovies() { MovieId = 9, ActorId = 16 },
             new ActorsMovies() { MovieId = 10, ActorId = 17 },
             new ActorsMovies() { MovieId = 10, ActorId = 18 },
             new ActorsMovies() { MovieId = 11, ActorId = 19 },
             new ActorsMovies() { MovieId = 11, ActorId = 20 },
             new ActorsMovies() { MovieId = 12, ActorId = 21 },
             new ActorsMovies() { MovieId = 12, ActorId = 22 },
             new ActorsMovies() { MovieId = 13, ActorId = 23 },
             new ActorsMovies() { MovieId = 13, ActorId = 24 },
             new ActorsMovies() { MovieId = 14, ActorId = 25 },
             new ActorsMovies() { MovieId = 15, ActorId = 26 },
             new ActorsMovies() { MovieId = 16, ActorId = 27 },
             new ActorsMovies() { MovieId = 17, ActorId = 28 },
             new ActorsMovies() { MovieId = 18, ActorId = 29 },
             new ActorsMovies() { MovieId = 19, ActorId = 30 },
             new ActorsMovies() { MovieId = 20, ActorId = 31 },
             new ActorsMovies() { MovieId = 21, ActorId = 32 },
             new ActorsMovies() { MovieId = 22, ActorId = 33 },
             new ActorsMovies() { MovieId = 23, ActorId = 14 }
             );
        }
    }
}
