using eCInema.Models.Dtos.Halls;
using eCInema.Models.Dtos.Movies;
using eCInema.Models.Dtos.SchedulesSeats;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Schedules
{
    public class GetSchedulesDto
    {
        public int Id { get; set; }
        //  public MovieDto Movie { get; set; }
        // public MovieDetailsDto Movie { get; set; }  
        public GetMoviesDto Movie { get; set; }
       // public int MovieId { get; set; }
        public DateTime Date { get; set; }
        public string? DayOfWeek { get => Date.DayOfWeek.ToString(); }
        public string DateOnly { get => Date.ToShortDateString(); }
        public DateTime StartTime { get; set; }
        public string TimeOnly { get => StartTime.ToShortTimeString(); }
        public DateTime? EndTime { get; set; }
        public HallDto Hall { get; set; }
        public List<ScheduleSeatDto> ScheduleSeats { get; set; }
        public int? NoAvailableSeats { get; set; }
        public float? TicketPrice { get; set; }

    }
}
