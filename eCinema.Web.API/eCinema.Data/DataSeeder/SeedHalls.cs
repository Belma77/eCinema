using eCInema.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Data.DataSeeder
{
    public class SeedHallsData
    {
        public static void SeedHalls(ModelBuilder builder)
        {
            for (int i = 1; i <= 6; i++)
            {
                builder.Entity<Hall>().HasData(
                    new Hall() { Id = i, NoOfHall = i, NumberOfColumns = 10, NumberOfRows = 5, NumberOfSeats = 50 }
                    );
            }
        }
    }
}
