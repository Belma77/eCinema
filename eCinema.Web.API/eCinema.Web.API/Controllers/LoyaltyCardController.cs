using eCinema.Services.LoyalCardServices;
using eCInema.Models.Dtos.Customer;
using eCInema.Models.Dtos.LoyaltyCard;
using eCInema.Models.Enums;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using AuthorizeAttribute = eCinema.Web.API.Auth.CustomAuthorizeAttribute;

namespace eCinema.Web.API.Controllers
{
    [Route("LoyaltyClub")]
    [ApiController]
    public class LoyaltyCardController : BaseController<LoyalCardDto, LoyalCardSearchObject>
    {
        ILoyalCardService _service;
        public LoyaltyCardController(ILoyalCardService service):base(service)
        {
            _service = service;
        }

        [Authorize(UserRole.Admin, UserRole.Customer)]
        [HttpPost]
        public IActionResult Add(LoyalCardInsertDto insert)
        {
            return Ok(_service.Insert(insert));

        }

        [Authorize(UserRole.Admin)]
        [HttpGet]
        public override IActionResult Get(LoyalCardSearchObject? search)
        {
            return Ok(_service.Get(search));
        }

        [Authorize(UserRole.Admin)]
        [HttpGet("{id}")]
        public override IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
            
        }

        [Authorize(UserRole.Customer, UserRole.Admin)]
        [HttpGet("AlreadyLoyal/{id}")]
        public IActionResult AlreadyExists(int id)
        {
            return Ok(_service.Exists(id));
        }

    }
}
