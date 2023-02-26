using AutoMapper;
using eCinema.Data;
using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Halls;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.HallServices
{
    public class HallService:BaseCRUDService<HallDto, Hall, HallSearchObject, HallDto, HallUpdateDto>, IHallService
    {
        public HallService(eCinemaContext context, IMapper mapper):base(context, mapper)
        {

        }
    }
}
