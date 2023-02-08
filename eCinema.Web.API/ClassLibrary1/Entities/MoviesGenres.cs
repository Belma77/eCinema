using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCInema.Data.Entities;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace eCInema.Models.Entities
{
    public class MoviesGenres
    {
        public Movies Movie { get; set; }
        public int MovieId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Genres Genre { get; set; }
        public int GenreId { get; set; }
        public override bool Equals(object? obj)
        {
            var item=obj as MoviesGenres;

            if (item==null) return false;

            if (item.MovieId == this.MovieId && this.Genre == item.Genre) return true;

            if (item.MovieId == this.MovieId && this.GenreId == item.GenreId) return true;
            
            return false;


        }
    }
}
