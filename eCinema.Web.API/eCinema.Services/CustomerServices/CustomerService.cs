using AutoMapper;
using eCinema.Data;
using eCinema.Data.Migrations;
using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Customer;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.CustomerServices
{
    public class CustomerService:BaseCRUDService<CustomerDto, Customer, CustomerSearchObject, CustomerDto, UpdateCustomerDto>, ICustomerService
    {
        public CustomerService(eCinemaContext context, IMapper mapper):base(context, mapper)    
        {

        }

        public override IQueryable<Customer> AddFilter(IQueryable<Customer> query, CustomerSearchObject search = null)
        {
            if (!String.IsNullOrEmpty(search.Name))
                query = query.Where(x => x.FirstName.ToLower().StartsWith(search.Name.ToLower())
                || (x.LastName.ToLower().StartsWith(search.Name.ToLower()))
                || (x.FirstName + " " + x.LastName).ToLower().StartsWith(search.Name.ToLower()));

            return query;
        }
    }
}
