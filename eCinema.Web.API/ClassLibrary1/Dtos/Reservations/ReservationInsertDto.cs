using eCInema.Models.Dtos.Customer;
using eCInema.Models.Dtos.Movie;
using eCInema.Models.Dtos.Schedules;
using eCInema.Models.Dtos.SchedulesSeats;
using eCInema.Models.Entities;
using eCInema.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Reservations
{
    public class ReservationInsertDto
    {
        public int? CustomerId { get; set; }
        public int ScheduleId { get; set; }
        public int NumberOfTickets { get; set; }
        public List<ScheduleSeatDto> scheduleSeats { get; set; }
        public ReservationStatusEnum Status { get; set; }
    }
}
