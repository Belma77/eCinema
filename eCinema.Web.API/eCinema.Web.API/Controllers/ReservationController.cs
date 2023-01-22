using eCinema.Services.Resrevations;
using eCInema.Models.Dtos.Reservations;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCinema.Web.API.Controllers
{
    [Route("Reservation")]
    [ApiController]
    public class ReservationController : BaseCRUDController<ReservationDto, ReservationSearchObject, ReservationInsertDto, ReservationUpdateDto>
    {
        public ReservationController(IReservationService service):base(service)
        {

        }
    }
}
