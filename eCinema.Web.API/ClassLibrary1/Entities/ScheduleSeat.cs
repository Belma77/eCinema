using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Entities
{
    public class ScheduleSeat
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public int? SeatId { get; set; }
        public Seat Seat { get; set; }
        public bool isTaken { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            var seat = obj as ScheduleSeat;
            return seat.SeatId == SeatId && seat.ScheduleId == ScheduleId;
        }
    }
}
