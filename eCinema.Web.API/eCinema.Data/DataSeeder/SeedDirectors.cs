using eCInema.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Data.DataSeeder
{
    public class SeedDirectorsData
    {
        public static void SeedDirectors(ModelBuilder builder)
        {
            builder.Entity<Director>().HasData(
             new Director() { Id = 1, FirstName = "Chris", LastName = "Columbus" },
             new Director() { Id = 2, FirstName = "David F.", LastName = "Sandberg" },
             new Director() { Id = 3, FirstName = "Chad", LastName = "Stahelski" },
             new Director() { Id = 4, FirstName = "Michael B.", LastName = "Jordan" },
             new Director() { Id = 5, FirstName = "Mihael", LastName = "Jacobs" },
             new Director() { Id = 6, FirstName = "Martin", LastName = "McDonaugh" },
             new Director() { Id = 7, FirstName = "Damien", LastName = "Chazelle" },
             new Director() { Id = 8, FirstName = "Baz", LastName = "Luhrmann" },
             new Director() { Id = 9, FirstName = "Joseph", LastName = "Kosinski" },
             new Director() { Id = 10, FirstName = "James", LastName = "Cameron" },
             new Director() { Id = 11, FirstName = "Ryan", LastName = "Coogler" },
             new Director() { Id = 12, FirstName = "Steven", LastName = "Spielberg" },
             new Director() { Id = 13, FirstName = "Darren", LastName = "Aronofsky" },
             new Director() { Id = 14, FirstName = "Ruben", LastName = "Ostlund" },
             new Director() { Id = 15, FirstName = "Rhys", LastName = "Waterfield" },
             new Director() { Id = 16, FirstName = "Elizabeth", LastName = "Banks" },
             new Director() { Id = 17, FirstName = "Toni", LastName = "Garcia" },
             new Director() { Id = 18, FirstName = "Peyton", LastName = "Reed" },
             new Director() { Id = 19, FirstName = "Shekhar", LastName = "Kapur" },
             new Director() { Id = 20, FirstName = "Steven", LastName = "Soderbergh" },
             new Director() { Id = 21, FirstName = "Guillaume", LastName = "Canet" },
             new Director() { Id = 22, FirstName = "Marc", LastName = "Forster" }
             ) ;
        }
    }
}
