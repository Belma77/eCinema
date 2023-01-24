using eCInema.Models.Dtos.Genres;
using eCInema.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.SearchObjects
{
    public class GenresSearchObject:BaseSearchObject
    {
        public GenresDto Genres{ get; set; }

    }
}
