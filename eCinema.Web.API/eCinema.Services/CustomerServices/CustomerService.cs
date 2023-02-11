﻿using AutoMapper;
using eCinema.Data;
using eCinema.Data.Migrations;
using eCinema.Services.CRUDservice;
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
            if (!String.IsNullOrEmpty(search.Name))
                query = query.Where(x => x.FirstName.ToLower().StartsWith(search.Name.ToLower())
                || (x.LastName.ToLower().StartsWith(search.Name.ToLower()))
                || (x.FirstName + " " + x.LastName).ToLower().StartsWith(search.Name.ToLower()));

            if (!String.IsNullOrEmpty(search.Username))
                query = query.Where(x => x.UserName==search.Username);

            return query;
        }

        public override CustomerDto Insert(CustomerInsertDto insert)
        {
            var entity = _mapper.Map<Customer>(insert);
            var salt = GenerateSalt();
            entity.PasswordSalt = salt;
            entity.PasswordHash = GenerateHash(salt, insert.Password);

            if (entity.UserRole == eCInema.Models.Enums.UserRole.Customer && insert.CustomerType == null)
            {
                var customer = _mapper.Map<Customer>(entity);
                customer.CustomerType = eCInema.Models.Enums.CustomerTypeEnum.Regular;
                _context.Customers.Add(customer);
            }
            else
            {
                _context.Users.Add(entity);
            }
            _context.SaveChanges();
            return _mapper.Map<CustomerDto>(entity);
        }

        public CustomerDto getCurrent()
        {
            var user=_accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (user == null)
                throw new NotFoundException("Customer not found");
            var customer = _context.Customers.FirstOrDefault(x => x.UserName == user);

            if (customer == null)
               throw new NotFoundException("Customer not found");

            return _mapper.Map<CustomerDto>(customer);

        }
        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);
            return Convert.ToBase64String(byteArray);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}
