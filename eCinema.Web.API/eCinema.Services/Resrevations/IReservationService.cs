﻿using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Reservations;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.Resrevations
{
    public interface IReservationService:IBaseCRUDService<ReservationDto, ReservationSearchObject, ReservationInsertDto, ReservationUpdateDto>
    {

    }
}