using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Entities
{
    public class ActorsMovies
    {
        public Actor? Actor{ get; set; }
        public int ActorId { get; set; }
        public Movies? Movie { get; set; }
        public int MovieId { get; set; }
    }
}
