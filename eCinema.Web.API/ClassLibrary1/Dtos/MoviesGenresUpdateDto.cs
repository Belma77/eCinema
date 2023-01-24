using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCInema.Models.Dtos.Genres;

namespace eCInema.Models.Dtos
{
    public class MoviesGenresUpdateDto
    {
        public int MovieId { get; set; }
        public  GenresDto Genre { get; set; }

    }
}
