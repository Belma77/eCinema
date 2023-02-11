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
        public string? City { get; set; }
        public string? IdentificationNumber { get; set; }
        public CustomerTypeEnum CustomerType { get; set; }
    }
}
