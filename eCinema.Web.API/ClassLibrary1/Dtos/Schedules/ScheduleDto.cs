using eCInema.Models.Dtos.Halls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Schedules
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string DayOfWeek { get => Date.DayOfWeek.ToString(); }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public HallDto Hall { get; set; }
        public int NoAvailableSeats { get; set; }
    }
}
