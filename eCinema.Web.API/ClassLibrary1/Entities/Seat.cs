using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public int Column { get; set; }
        public string Row { get; set; }
        public int? HallId { get; set; }
        public Hall Hall { get; set; }


    }
}
