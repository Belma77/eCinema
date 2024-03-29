﻿using eCinema.Services.CustomerServices;
using eCInema.Models.Dtos.Customer;
using eCInema.Models.Enums;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthorizeAttribute = eCinema.Web.API.Auth.CustomAuthorizeAttribute;

namespace eCinema.Web.API.Controllers
{
    [Route("Customer")]
    [ApiController]
    public class CustomersController : BaseCRUDController<CustomerDto, CustomerSearchObject, CustomerInsertDto, UpdateCustomerDto>
    {
        ICustomerService _service;
        public CustomersController(ICustomerService service):base(service)
        {
            _service=service;
        }

        [AllowAnonymous]
        public override IActionResult Insert(CustomerInsertDto insert)
        {
            return Ok(base.Insert(insert));
        }

        [Authorize(UserRole.Admin)]
        public override IActionResult Get(CustomerSearchObject? search)
        {
            return base.Get(search);
        }

        [Authorize(UserRole.Admin)]
        [HttpGet("{id}")]
        public override IActionResult GetById(int id)
        {
            return base.GetById(id);
        }


        [Authorize(UserRole.Customer)]
        [HttpPut("{id}")]
        public override IActionResult Update(int id, UpdateCustomerDto update)
        {
            return base.Update(id, update);
        }


        [Authorize(UserRole.Customer, UserRole.Admin)]
        [HttpDelete("{id}")]
        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }


        [Authorize(UserRole.Admin, UserRole.Customer)]
        [HttpGet("Current")]
        public IActionResult GetCurrent()
        {
            return Ok(_service.getCurrent());
        }

        [HttpGet("UsernameExists")]
        [AllowAnonymous]
        public IActionResult UsernameExists([FromQuery] string username)
        {
            return Ok(_service.usernameExists(username));
        }


    }
}
