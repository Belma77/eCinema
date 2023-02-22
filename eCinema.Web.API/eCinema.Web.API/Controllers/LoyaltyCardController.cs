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
    [Authorize(UserRole.Admin, UserRole.Customer)]
    public class LoyaltyCardController : BaseController<LoyalCardDto, LoyalCardSearchObject>
    {
        ILoyalCardService _service;
        public LoyaltyCardController(ILoyalCardService service):base(service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(UserRole.Admin, UserRole.Customer)]
        public IActionResult Add(LoyalCardInsertDto insert)
        {
            return Ok(_service.Insert(insert));

        }
       
    }
}
