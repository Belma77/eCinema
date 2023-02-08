using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Customer;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.CustomerServices
{
    public interface ICustomerService:IBaseCRUDService<CustomerDto, CustomerSearchObject, CustomerInsertDto, UpdateCustomerDto>
    {
        
    }
}
