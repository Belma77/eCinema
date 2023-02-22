using eCInema.Models.Dtos.Customer;
using eCInema.Models.Dtos.Movies;
using eCInema.Models.Dtos.Schedules;
using eCInema.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Reservations
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public CustomerDto Customer { get; set; }
        public int CustomerId { get; set; }
        public GetSchedulesDto Schedule { get; set; }
        public int ScheduleId { get; set; }
        public int NumberOfTickets { get; set; }
        public ReservationStatusEnum Status { get; set; }
        public double Price { get; set; }

    }
}
