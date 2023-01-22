using eCInema.Models.Dtos.Customer;
using eCInema.Models.Dtos.Movies;
using eCInema.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Reservations
{
    public class ReservationInsertDto
    {
        public CustomerDto Customer { get; set; }
        public int CustomerId { get; set; }
        public MovieDto Movie { get; set; }
        public int MovieId { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfTickets { get; set; }
        public ReservationStatusEnum Status { get; set; }
    }
}
