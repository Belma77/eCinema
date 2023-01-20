using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Entities
{
    public class DirectorsMovies
    {
        public Movies? Movie { get; set; }
        public int  MovieId { get; set; }
        public Director? Director { get; set; }
        public int DirectorId { get; set; }
    }
}
