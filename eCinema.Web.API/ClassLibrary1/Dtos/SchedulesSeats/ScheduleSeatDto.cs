using eCInema.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.SchedulesSeats
{
    public class ScheduleSeatDto
    {
        public int SeatId { get; set; }
        public int ScheduleId { get; set; }
    }
}
