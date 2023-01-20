using eCInema.Models;
using eCInema.Models.Entities;
using eCInema.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eCInema.Data.Entities
{
    public class Genres
    {
        public int Id { get; set; }
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
