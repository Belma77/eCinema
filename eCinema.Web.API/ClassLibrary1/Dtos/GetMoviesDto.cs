using eCInema.Data.Entities;
using eCInema.Models.Entities;
using eCInema.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos
{
    public class GetMoviesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
        public string Country { get; set; }
       
    }
}
