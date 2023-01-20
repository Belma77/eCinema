using eCInema.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos
{
    public class MoviesGenresDto
    {
        public GenresDto Genre { get; set; }
        public MovieDetailsDto Movie { get; set; }
        public int MovieId { get; set; }
        public override string ToString()
        {
            return this.Genre.ToString();
        }
    }
}
