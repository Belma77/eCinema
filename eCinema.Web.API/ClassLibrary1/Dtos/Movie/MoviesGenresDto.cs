using eCInema.Data.Entities;
using eCInema.Models.Dtos.Genres;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Movie
{
    public class MoviesGenresDto
    {
        public GenresDto Genre { get; set; }
        public int MovieId { get; set; }
        public override string ToString()
        {
            return Genre.ToString();
        }
    }
}
