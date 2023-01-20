using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos
{
    public class CastMoviesDto<T> where T : class
    {
        public T CastDto { get; set; }
        public int MovieId { get; set; }
    }
}
