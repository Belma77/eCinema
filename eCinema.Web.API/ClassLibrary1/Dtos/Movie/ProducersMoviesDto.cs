using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Movie
{
    public class ProducersMoviesDto
    {
        public ProducerDto? Producer { get; set; }
        public int MovieId { get; set; }
        public override bool Equals(object obj)
        {
            var item = obj as ProducersMoviesDto;
            if (item == null)
                return false;
            return Producer.Equals(item.Producer) && MovieId == item.MovieId;
        }
    }


}
