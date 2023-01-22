using eCInema.Models.Dtos.Customer;
using eCInema.Models.Dtos.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.SearchObjects
{
    public class ReservationSearchObject
    {
        public string? CustomerName { get; set; }
        public string? Movie { get; set; }

    }
}
