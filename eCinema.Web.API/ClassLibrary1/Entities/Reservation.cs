using eCInema.Models.Dtos.Customer;
using eCInema.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Entities
{
    public class Reservation
    {
        public  int Id { get; set; }
        public Customer Customer{ get; set; }
        public int CustomerId { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public int NumberOfTickets { get; set; }
        public double Price { get; set; }
        public List<ScheduleSeat> ScheduleSeat { get; set; }
        public ReservationStatusEnum Status { get; set; }

    }
}
