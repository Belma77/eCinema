using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Seats
{
    public class SeatDto
    {
        public int Id { get; set; }
        public int Column { get; set; }
        public string Row { get; set; }
    }
}
