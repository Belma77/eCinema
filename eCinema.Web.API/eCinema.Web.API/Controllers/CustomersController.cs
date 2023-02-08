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
        public CustomersController(ICustomerService service):base(service)
        {

        }

        [AllowAnonymous]
        public override IActionResult Insert(CustomerInsertDto insert)
        {
            return base.Insert(insert);
        }
    }
}
