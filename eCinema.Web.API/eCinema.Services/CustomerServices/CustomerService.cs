using AutoMapper;
using eCinema.Data;
using eCinema.Services.CRUDservice;
using eCinema.Services.Helpers;
using eCinema.Services.UserServices;
using eCInema.Models.Dtos.Customer;
using eCInema.Models.Dtos.Users;
using eCInema.Models.Entities;
using eCInema.Models.Exceptions;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.CustomerServices
{
    public class CustomerService:BaseCRUDService<CustomerDto, Customer, CustomerSearchObject, CustomerInsertDto, UpdateCustomerDto>, ICustomerService
    {
        IHttpContextAccessor _accessor;
        public CustomerService(eCinemaContext context, IMapper mapper, IHttpContextAccessor accessor):base(context, mapper)    
        {
            _accessor = accessor;

        }

        public override IQueryable<Customer> AddFilter(IQueryable<Customer> query, CustomerSearchObject search = null)
        {
            if (!string.IsNullOrEmpty(search.Name))
                query = query.Where(x => x.FirstName.ToLower().Contains(search.Name.ToLower())
                || (x.LastName.ToLower().Contains(search.Name.ToLower()))
                || (x.FirstName + " " + x.LastName).ToLower().Contains(search.Name.ToLower()));

            if (!string.IsNullOrEmpty(search.Username))
                query = query.Where(x => x.UserName.ToLower()==search.Username.ToLower());

            if(!string.IsNullOrEmpty(search.FirstName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.LastName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
            }

            return query;
        }

        public override CustomerDto Insert(CustomerInsertDto insert)
        {
            var customerExists = _context.Customers.FirstOrDefault(x => x.UserName == insert.UserName);
            if(customerExists != null)
            {
                throw new BadRequestException("Customer with that username already exists");
            }
            var entity = _mapper.Map<Customer>(insert);
            var salt = PasswordHelper.GenerateSalt();
            entity.PasswordSalt = salt;
            entity.PasswordHash = PasswordHelper.GenerateHash(salt, insert.Password);
            entity.CustomerType = eCInema.Models.Enums.CustomerTypeEnum.Regular;
            _context.Customers.Add(entity);
          
            _context.SaveChanges();
            return _mapper.Map<CustomerDto>(entity);
        }
        
        public CustomerDto getCurrent()
        {
            var user=_accessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
           
            var customer = _context.Customers.FirstOrDefault(x => x.UserName == user);

            if (customer == null)
               throw new NotFoundException("Customer not found");

            return _mapper.Map<CustomerDto>(customer);

        }

        public bool usernameExists(string username)
        {
            var usernameDb = _context.Customers.FirstOrDefault(x=>x.UserName==username);
            if (usernameDb != null)
                return true;
            return false;
        }
        
    }
}

