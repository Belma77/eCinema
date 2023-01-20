using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos
{
    public class WritersMoviesDto
    {
        public WriterDto? Writer { get; set; }
        public int MovieId { get; set; }
    }
}
