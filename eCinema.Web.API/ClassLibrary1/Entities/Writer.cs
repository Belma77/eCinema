using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Entities
{
    public class Writer:Cast
    {
        public List<WritersMovies>? WritersMovies { get; set; }
    }
}
