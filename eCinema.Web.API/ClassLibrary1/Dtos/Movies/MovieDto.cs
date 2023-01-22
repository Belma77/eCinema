using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Movies
{
    public class MovieDto
    {
        public string Title { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}
