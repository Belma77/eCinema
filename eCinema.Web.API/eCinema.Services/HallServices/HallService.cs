﻿using AutoMapper;
using eCinema.Data;
using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Hall;
using eCInema.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.HallServices
{
    public class HallService:BaseCRUDService<HallDto, Hall, HallDto, HallDto, HallUpdateDto>, IHallService
    {
        public HallService(eCinemaContext context, IMapper mapper):base(context, mapper)
        {

        }
    }
}