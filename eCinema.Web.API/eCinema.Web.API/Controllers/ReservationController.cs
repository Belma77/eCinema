using eCinema.Services.Resrevations;
using eCInema.Models.Dtos.Reservations;
using eCInema.Models.Entities;
using eCInema.Models.Enums;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthorizeAttribute = eCinema.Web.API.Auth.CustomAuthorizeAttribute;

namespace eCinema.Web.API.Controllers
{
    [Route("Reservation")]
    [ApiController]
    public class ReservationController : BaseCRUDController<ReservationDto, ReservationSearchObject, ReservationInsertDto, ReservationUpdateDto>
    {
        public ReservationController(IReservationService service):base(service)
        {

        }
        [AllowAnonymous]
        [Authorize(UserRole.Customer, UserRole.Admin)]
        public override IActionResult Insert(ReservationInsertDto insert)
        {
            return base.Insert(insert);
        }

    }
}
