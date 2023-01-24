using eCInema.Models.Dtos.Movies;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Schedule
{
    public class ScheduleUpdateDto
    {
        public int MovieId { get; set; }
        public MovieDto Movie { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int NoHall { get; set; }
    }
}
