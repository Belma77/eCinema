using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movies Movie { get; set; } 
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int HallId { get; set; }
        public double TicketPrice { get; set; }
        public Hall Hall { get; set; }
        public List<ScheduleSeat> ScheduleSeats { get; set; }
        public int NoAvailableSeats { get; set; }

    }
}
