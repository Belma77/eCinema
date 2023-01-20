using MediaBrowser.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Entities
{
    public class Cast
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override bool Equals(object? obj)
        {
            var item = obj as Cast;

            if (item == null)
            {
                return false;
            }

            return this.FirstName.ToLower().Equals(item.FirstName.ToLower())&&this.LastName.ToLower().Equals(item.LastName.ToLower());
        }
    }
}
