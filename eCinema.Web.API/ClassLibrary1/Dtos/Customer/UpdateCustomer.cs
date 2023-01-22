using eCInema.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Customer
{
    public class UpdateCustomerDto
    {
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public CustomerTypeEnum CustomerType { get; set; }
    }
}
