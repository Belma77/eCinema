using eCinema.Services.CustomerServices;
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
    [Authorize(UserRole.Admin)]
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
            return base.Insert(insert);
        }


        [AllowAnonymous]
        [Authorize(UserRole.Customer)]
        [HttpPut("{id}")]
        public override IActionResult Update(int id, UpdateCustomerDto update)
        {
            return base.Update(id, update);
        }


        [AllowAnonymous]
        [Authorize(UserRole.Customer, UserRole.Admin)]
        [HttpDelete("{id}")]
        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }


        [AllowAnonymous]
        [Authorize(UserRole.Admin, UserRole.Customer)]
        [HttpGet("Current")]
        public IActionResult GetCurrent()
        {
            return Ok(_service.getCurrent());
        }


    }
}
