using eCInema.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Entities
{
    public class Customer:User
    {       
        public CustomerTypeEnum CustomerType { get; set; }
    }
}
