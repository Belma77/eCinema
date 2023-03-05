using eCInema.Data.Entities;
using eCInema.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Data.DataSeeder
{
    public class SeedGenresData
    {
        public static void SeedGenres(ModelBuilder builder)
        {
            builder.Entity<Genres>().HasData(
                new Genres() { Id = 1, Genre = GenresEnum.Action },
                new Genres() { Id = 2, Genre = GenresEnum.Comedy },
                new Genres() { Id = 3, Genre = GenresEnum.Crime },
                new Genres() { Id = 4, Genre = GenresEnum.Horror },
                new Genres() { Id = 5, Genre = GenresEnum.Adventure },
                new Genres() { Id = 6, Genre = GenresEnum.ScienceFiction },
                new Genres() { Id = 7, Genre = GenresEnum.Thriller },
                new Genres() { Id = 8, Genre = GenresEnum.Animation },
                new Genres() { Id = 9, Genre = GenresEnum.Biographical },
                new Genres() { Id = 10, Genre = GenresEnum.Documentary },
                new Genres() { Id = 11, Genre = GenresEnum.Drama },
                new Genres() { Id = 12, Genre = GenresEnum.History },
                new Genres() { Id = 13, Genre = GenresEnum.Musical },
                new Genres() { Id = 14, Genre = GenresEnum.Mystery },
                new Genres() { Id = 15, Genre = GenresEnum.Romantic },
                new Genres() { Id = 16, Genre = GenresEnum.Family }
                );
        }
    }
}
