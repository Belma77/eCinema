using eCInema.Models.Dtos.Halls;
using eCInema.Models.Dtos.Movies;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Schedule
{
    public class GetSchedulesDto
    {
        public int Id { get; set; }
        public MovieDto Movie { get; set; }
        public int MovieId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public HallDto Hall { get; set; }
        public int NoAvailableSeats { get; set; }
    }
}
