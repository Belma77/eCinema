using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Entities
{
    public class Producer : Cast
    {
        public List<ProducerMovies>? ProducerMovies { get; set; }
        public override bool Equals(object? obj)
        {
            var item=obj as Producer;
            if (item == null) return false;
            return item.FirstName.Equals(this.FirstName) && item.LastName.Equals(this.LastName);
        }
    }
}
