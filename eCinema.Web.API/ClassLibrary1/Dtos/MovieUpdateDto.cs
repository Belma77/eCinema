using eCInema.Data.Entities;
using eCInema.Models.Dtos;
using eCInema.Models.Entities;
using eCInema.Models.Enums;
using MediaBrowser.Model.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Data.Dtos
{
    public  class MovieUpdateDto
    {

        public string? Title { get; set; }
        public string? Synopsis { get; set; }
        public int? ReleaseYear { get; set; }
        public List<GenresDto>? Genres { get; set; }
        public int? Duration { get; set; }
        public string? Country { get; set; }
        public List<ActorsMoviesDto>? Actors { get; set; }
        public List<DirectorsMoviesDto>? Directors { get; set; }
        public List<WritersMoviesDto>? Writers { get; set; }
        public List<ProducersMoviesDto>? Producers { get; set; }
        public byte[]? Poster { get; set; }
    }
}
