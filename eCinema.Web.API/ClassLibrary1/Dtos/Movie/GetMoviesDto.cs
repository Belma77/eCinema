using eCInema.Data.Entities;
using eCInema.Models.Entities;
using eCInema.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Movie
{
    public class GetMoviesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
        public string Synopsis { get; set; }
        public string Country { get; set; }
        public byte[] Poster { get; set; }
        //public List<MoviesGenresDto>? MoviesGenres { get; set; }
        //public List<ActorsMoviesDto>? ActorsMovies { get; set; }
        //public List<DirectorsMoviesDto>? DirectorsMovies { get; set; }
        //public List<ProducersMoviesDto>? ProducersMovies { get; set; }
        //public List<WritersMoviesDto>? WritersMovies { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
