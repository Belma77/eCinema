using eCInema.Models;
using eCInema.Models.Entities;
using eCInema.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eCInema.Data.Entities
{
    public class Genres
    {
        public int Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public GenresEnum Genre { get; set; }
        public List<MoviesGenres>? MoviesGenres { get; set; }

        public override bool Equals(object? obj)
        {
            var item=obj as Genres;
            if(item==null) return false;
            return this.Genre == item.Genre;
        }

    }
}
