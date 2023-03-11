using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.SearchObjects
{
    public class ScheduleSearchObject:BaseSearchObject
    {
        public string? Title { get; set; }
        public int? MovieId { get; set; }
        public DateTime? Date { get; set; }
        //public DateTime? StartTime { get; set; }
        public string? StartTime { get; set; }

        public string? DayOfWeek { get; set; }
    }
}
