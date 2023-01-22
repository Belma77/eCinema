using eCinema.Services.CustomerServices;
using eCInema.Models.Dtos.Customer;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Web.API.Controllers
{
    [Route("Customer")]
    [ApiController]
    public class CustomersController : BaseCRUDController<CustomerDto, CustomerSearchObject, CustomerDto, UpdateCustomerDto>
    {
        public CustomersController(ICustomerService service):base(service)
        {

        }
    }
}
