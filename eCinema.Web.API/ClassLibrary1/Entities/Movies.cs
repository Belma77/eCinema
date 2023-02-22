using eCInema.Data.Entities;
using eCInema.Models.Entities;
using eCInema.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Synopsis { get; set; }
        public int ReleaseYear { get; set; }
        public int  Duration { get; set; }
        public List<MoviesGenres>? MoviesGenres { get; set; }
        public string Country { get; set; } 
        public List<DirectorsMovies>? DirectorsMovies { get; set; }
        public List<ActorsMovies>? ActorsMovies { get; set; }
        public List<ProducerMovies> ProducersMovies { get; set; }
        public List<WritersMovies> WritersMovies { get; set; }
        public byte[]? Poster { get; set; }//promijeniti iz nullabla
        public List<Schedule>? Schedules { get; set; }
    }
}
