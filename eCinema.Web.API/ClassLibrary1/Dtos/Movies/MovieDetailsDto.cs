using eCInema.Data.Entities;
using eCInema.Models.Dtos.Schedules;
using eCInema.Models.Entities;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Movies
{
    public class MovieDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
        public List<MoviesGenresDto>? MoviesGenres { get; set; }
        public string Country { get; set; }
        public List<ActorsMoviesDto>? ActorsMovies { get; set; }
        public List<DirectorsMoviesDto>? DirectorsMovies { get; set; }
        public List<ProducersMoviesDto>? ProducersMovies { get; set; }
        public List<WritersMoviesDto>? WritersMovies { get; set; }
        public List<ScheduleDto>? Schedules { get; set; }
        public byte[] Poster { get; set; }
    }
}
