using eCInema.Models.Dtos.Schedules;
using eCInema.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Movie
{
    public class MovieSales
    {
       public Movies Movie { get; set; }
       public double Sales { get; set; }
       
    }
}
