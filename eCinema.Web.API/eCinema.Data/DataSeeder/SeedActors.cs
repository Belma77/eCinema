using eCInema.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Data.DataSeeder
{
    public class SeedActorsData
    {
        public static void SeedActors(ModelBuilder builder)
        {
            builder.Entity<Actor>().HasData(
            new Actor() { Id = 1, FirstName = "Daniel", LastName = "Radcliffe" },
            new Actor() { Id = 2, FirstName = "Keanu", LastName = "Reeves" },
            new Actor() { Id = 3, FirstName = "Donnie", LastName = "Yen" },
            new Actor() { Id = 4, FirstName = "Zachary", LastName = "Levi" },
            new Actor() { Id = 5, FirstName = "Michael B.", LastName = "Jordan" },
            new Actor() { Id = 6, FirstName = "Jonathon", LastName = "Mayors" },
            new Actor() { Id = 7, FirstName = "Emma", LastName = "Roberts" },
            new Actor() { Id = 8, FirstName = "Richard", LastName = "Gere" },
            new Actor() { Id = 9, FirstName = "Colin", LastName = "Farell" },
            new Actor() { Id = 10, FirstName = "Brendon", LastName = "Gleeson" },
            new Actor() { Id = 11, FirstName = "Brad", LastName = "Pitt" },
            new Actor() { Id = 12, FirstName = "Margot", LastName = "Robbie" },
            new Actor() { Id = 13, FirstName = "Austin", LastName = "Butler" },
            new Actor() { Id = 14, FirstName = "Tom", LastName = "Hanks" },
            new Actor() { Id = 15, FirstName = "Tom", LastName = "Cruise" },
            new Actor() { Id = 16, FirstName = "Miles", LastName = "Teller" },
            new Actor() { Id = 17, FirstName = "Zoe", LastName = "Saldana" },
            new Actor() { Id = 18, FirstName = "Vin", LastName = "Diesel" },
            new Actor() { Id = 19, FirstName = "Martin", LastName = "Freeman" },
            new Actor() { Id = 20, FirstName = "Letitia", LastName = "Wright" },
            new Actor() { Id = 21, FirstName = "Michelle", LastName = "Williams" },
            new Actor() { Id = 22, FirstName = "Gabriel", LastName = "LaBelle" },
            new Actor() { Id = 23, FirstName = "Brendan", LastName = "Fraser" },
            new Actor() { Id = 24, FirstName = "Sadie", LastName = "Sink" },
            new Actor() { Id = 25, FirstName = "Harris", LastName = "Dickinson" },
            new Actor() { Id = 26, FirstName = "Gillian", LastName = "Broderick" },
            new Actor() { Id = 27, FirstName = "Kerri", LastName = "Rusell" },
            new Actor() { Id = 28, FirstName = "Ronald", LastName = "Zlabur" },
            new Actor() { Id = 29, FirstName = "Paul", LastName = "Rudd" },
            new Actor() { Id = 30, FirstName = "Lily", LastName = "James" },
            new Actor() { Id = 31, FirstName = "Chaning", LastName = "Tatum" },
            new Actor() { Id = 32, FirstName = "Noa", LastName = "Zelenko" },
            new Actor() { Id = 33, FirstName = "Guillaume", LastName = "Canet" },
            new Actor() { Id = 34, FirstName = "Hellen", LastName = "Mirren" }


            );
         
        }
    }
}
