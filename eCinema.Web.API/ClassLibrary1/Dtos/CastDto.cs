using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos
{
    public class CastDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override bool Equals(object? obj)
        {
            var item=obj as CastDto;
             if(item==null) return false;

            return this.FirstName.ToLower().Equals(item.FirstName.ToLower()) && this.LastName.ToLower().Equals(item.LastName.ToLower());
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
