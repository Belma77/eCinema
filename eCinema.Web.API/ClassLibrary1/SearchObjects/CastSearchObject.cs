using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.SearchObjects
{
    public class CastSearchObject:BaseSearchObject
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
