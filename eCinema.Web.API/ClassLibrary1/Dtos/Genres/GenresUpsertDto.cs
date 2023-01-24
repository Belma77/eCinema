using eCInema.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Genres
{
    public class GenresUpsertDto
    {
        public GenresEnum Genre { get; set; }
    }
}
