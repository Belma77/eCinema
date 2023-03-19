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
        private IReservationService _service;
        public ReservationController(IReservationService service):base(service)
        {
            _service = service;
        }

        [Authorize(UserRole.Customer, UserRole.Admin)]
        [HttpPost]
        public override IActionResult Insert(ReservationInsertDto reservation)
        {
            return Ok(_service.Insert(reservation));
        }

        [Authorize(UserRole.Admin)]
        [HttpPut("{id}")]
        public override IActionResult Update(int id, ReservationUpdateDto reservation)
        {
            return Ok(_service.Update(id,reservation));
        }

        [Authorize(UserRole.Admin)]
        [HttpDelete("{id}")]
        public override IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }

        [Authorize(UserRole.Admin)]
        [HttpGet("{id}")]
        public override IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [Authorize(UserRole.Admin)]
        [HttpGet]
        public override IActionResult Get(ReservationSearchObject? search=null)
        {
            return Ok(_service.Get(search));
        }

        [HttpGet("ByCustomer")]
        [Authorize(UserRole.Admin)]
        public IActionResult GetReservationsByCustomer()
        {
            return Ok(_service.GetReservationsByCustomer());
        }
    }
}
