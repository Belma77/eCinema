using eCInema.Models.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Reservations
{
    public class SalesPerCustomer
    {
        public CustomerDto Customer { get; set; }
        public double Sales { get; set; }
    }
}
