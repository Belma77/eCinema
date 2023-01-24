﻿using eCinema.Services.HallServices;
using eCInema.Models.Dtos.Halls;
using eCInema.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthorizeAttribute = eCinema.Web.API.Auth.CustomAuthorizeAttribute;

namespace eCinema.Web.API.Controllers
{
    [Route("Hall")]
    [ApiController]
    [Authorize(UserRole.Admin)]
    public class HallController : BaseCRUDController<HallDto, HallDto, HallDto, HallUpdateDto>
    {
        public HallController(IHallService service):base(service)
        {

        }
    }
}
