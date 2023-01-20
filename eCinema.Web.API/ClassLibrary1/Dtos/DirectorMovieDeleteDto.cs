using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos
{
    public class DirectorMovieDeleteDto
    {
        public int MovieId{ get; set; }

        public int DirectorId { get; set; }
    }
}
