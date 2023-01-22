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

namespace eCInema.Models.Dtos.Movies
{
    public class MovieInsertDto
    {
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public int ReleaseYear { get; set; }
        //public List<int>? GenresIdList { get; set; }
        public List<GenresDto> Genres { get; set; }
        public int Duration { get; set; }
        public string Country { get; set; }
        public List<ActorDto>? Actors { get; set; }
        public List<DirectorDto>? Directors { get; set; }
        public List<WriterDto>? Writers { get; set; }
        public List<ProducerDto>? Producers { get; set; }
        public byte[] Poster { get; set; }
    }
}
