using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Entities
{
    public class Hall
    {
        public int Id { get; set; }
        public int NoOfHall { get; set; }
        public int NumberOfSeats { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}
