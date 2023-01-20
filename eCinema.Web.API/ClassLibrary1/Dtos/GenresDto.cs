using eCInema.Data.Entities;
using eCInema.Models.Enums;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos
{
    public class GenresDto
    {
        public int Id { get; set; }
        public GenresEnum Genre { get; set; }

        public override bool Equals(object? obj)
        {
            var item = obj as GenresDto;
            if(item == null) return false;

            return this.Genre == item.Genre;
        }

        public override string ToString()
        {
            return Genre.ToString();
        }
    }
}
