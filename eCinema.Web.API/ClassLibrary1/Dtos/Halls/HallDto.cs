using eCInema.Models.Dtos.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Halls
{
    public class HallDto
    {
        public int NoOfHall { get; set; }
        public int NumberOfSeats { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }
        public List<SeatDto> Seats { get; set; }
    }
}
