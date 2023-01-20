using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Entities
{
    public class ProducerMovies
    {
        public Producer? Producer { get; set; }
        public int ProducerId { get; set; }
        public Movies? Movie { get; set; }
        public int MovieId { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as ProducerMovies;
            if (item == null) return false;
            return this.Producer.Equals(item.Producer)
            && MovieId == item.MovieId;
        }

    }
}
