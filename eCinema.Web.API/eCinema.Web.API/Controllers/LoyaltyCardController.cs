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
        [HttpPost]
        [Route("Pay")]
        [AllowAnonymous]
        //[Authorize]
        public void CreateSession([FromBody] LoyalCardInsertDto card)
        {
            var url = "localhost:7239";
            try
            {
                var options = new SessionCreateOptions
                {
                    LineItems = _service.CreatesessionLineItemOptions(card),

                    Mode = "payment",
                    SuccessUrl = "http://localhost:4200/checkout",
                    CancelUrl = "http://localhost:4200/cancel",
                };

                var service = new SessionService();
                Session session = service.Create(options);
                Response.Headers.Add("Location", session.Url);
                Response.WriteAsJsonAsync(session.Url);

            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
    }
}
