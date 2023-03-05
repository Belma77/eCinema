using eCInema.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Data.DataSeeder
{
    public class SeedProducersData
    {
        public static void SeedProducers(ModelBuilder builder)
        {
            builder.Entity<Producer>().HasData(
               new Producer() { Id = 1, FirstName = "Duncan", LastName = "Henderson" },
               new Producer() { Id = 2, FirstName = "Richard", LastName = "Brener" },
               new Producer() { Id = 3, FirstName = "Cristoph", LastName = "Fisser" },
               new Producer() { Id = 4, FirstName = "William", LastName = "Chartoff" },
               new Producer() { Id = 5, FirstName = "Stephanie", LastName = "Heaton" },
               new Producer() { Id = 6, FirstName = "Daniel", LastName = "Battsek" },
               new Producer() { Id = 7, FirstName = "Michael", LastName = "Beugg" },
               new Producer() { Id = 8, FirstName = "Gail", LastName = "Berman" },
               new Producer() { Id = 9, FirstName = "Emily", LastName = "Chaung" },
               new Producer() { Id = 10, FirstName = "Richard", LastName = "Baneham" },
               new Producer() { Id = 11, FirstName = "Victoria", LastName = "Valenso" },
               new Producer() { Id = 12, FirstName = "Tonny", LastName = "Kushner" },
               new Producer() { Id = 13, FirstName = "Darren", LastName = "Aronofsky" },
               new Producer() { Id = 14, FirstName = "Philippe", LastName = "Bober" },
               new Producer() { Id = 15, FirstName = "Stuart", LastName = "Alson" },
               new Producer() { Id = 16, FirstName = "Niki", LastName = "Baida" },
               new Producer() { Id = 17, FirstName = "Stephen", LastName = "Hughes" },
               new Producer() { Id = 18, FirstName = "Victoria", LastName = "Alonso" },
               new Producer() { Id = 19, FirstName = "Tim", LastName = "Bevan" },
               new Producer() { Id = 20, FirstName = "Corey", LastName = "Baves" },
               new Producer() { Id = 21, FirstName = "Vivian", LastName = "Aslanian" },
               new Producer() { Id = 22, FirstName = "Xavier", LastName = "Amblard" },
               new Producer() { Id = 23, FirstName = "Neda", LastName = "Backman" }
               );
        }
    }
}
