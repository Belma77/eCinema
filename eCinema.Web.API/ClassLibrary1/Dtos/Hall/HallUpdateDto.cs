using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Hall
{
    public class HallUpdateDto
    {
        public int Id { get; set; }
        public int NoOfHall { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
