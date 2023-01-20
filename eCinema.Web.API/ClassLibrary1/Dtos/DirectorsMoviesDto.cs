using eCInema.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos
{
    public class DirectorsMoviesDto
    {
        public DirectorDto? Director{ get; set; }
        public int MovieId { get; set; }
    }
}
