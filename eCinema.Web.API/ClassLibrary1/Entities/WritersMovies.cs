using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Entities
{
    public class WritersMovies
    {
        public Writer? Writer { get; set; }
        public int WriterId { get; set; }
        public Movies? Movie { get; set; }
        public int MovieId { get; set; }

    }
}
