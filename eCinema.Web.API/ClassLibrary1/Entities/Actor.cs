using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Entities
{
    public class Actor : Cast
    {
        public List<ActorsMovies>? ActorsMovies { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
