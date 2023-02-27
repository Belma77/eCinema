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
        IReservationService _service;
        public ReservationController(IReservationService service):base(service)
        {
            _service = service;
        }

        [Authorize(UserRole.Customer, UserRole.Admin)]
        public override IActionResult Insert(ReservationInsertDto reservation)
        {
            return Ok(_service.Insert(reservation));
        }

        [HttpGet("ByCustomer")]
        [Authorize(UserRole.Admin)]
        public IActionResult GetReservationsByCustomer()
        {
            return Ok(_service.GetReservationsByCustomer());
        }
    }
}
