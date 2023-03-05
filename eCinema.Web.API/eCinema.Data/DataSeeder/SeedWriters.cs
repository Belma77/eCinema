using eCInema.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Data.DataSeeder
{
    public class SeedWritersData
    {
        public static void SeedWriters(ModelBuilder builder)
        {
            builder.Entity<Writer>().HasData(
                new Writer() { Id = 1, FirstName = "Steve", LastName = "Kloves" },
                new Writer() { Id = 2, FirstName = "Michael", LastName = "Finc" },
                new Writer() { Id = 3, FirstName = "Shay", LastName = "Hatten" },
                new Writer() { Id = 4, FirstName = "Hanry", LastName = "Gayden" },
                new Writer() { Id = 5, FirstName = "Kenan", LastName = "Koogler" },
                new Writer() { Id = 6, FirstName = "Michael", LastName = "Jacobs" },
                new Writer() { Id = 7, FirstName = "Martin", LastName = "McDonaugh" },
                new Writer() { Id = 8, FirstName = "Baz", LastName = "Luhrmann" },
                new Writer() { Id = 9, FirstName = "Jim", LastName = "Cash" },
                new Writer() { Id = 10, FirstName = "James", LastName = "Cameron" },
                new Writer() { Id = 11, FirstName = "Ryan", LastName = "Coogler" },
                new Writer() { Id = 12, FirstName = "Steven", LastName = "Spielberg" },
                new Writer() { Id = 13, FirstName = "Samuel D.", LastName = "Hunter" },
                new Writer() { Id = 14, FirstName = "Ruben", LastName = "Ostlund" },
                new Writer() { Id = 15, FirstName = "Rhys", LastName = "Waterfield" },
                new Writer() { Id = 16, FirstName = "Jimmy", LastName = "Warden" },
                new Writer() { Id = 17, FirstName = "Doug", LastName = "Langdale" },
                new Writer() { Id = 18, FirstName = "Jeff", LastName = "Loveness" },
                new Writer() { Id = 19, FirstName = "Jemmima", LastName = "Khann" },
                new Writer() { Id = 20, FirstName = "Reid", LastName = "Carolin" },
                new Writer() { Id = 21, FirstName = "Julien", LastName = "Rappeneu" },
                new Writer() { Id = 22, FirstName = "Renne", LastName = "Goscinny" },
                new Writer() { Id = 23, FirstName = "Frederick", LastName = "Backman" }
                );
        }
    }
}
