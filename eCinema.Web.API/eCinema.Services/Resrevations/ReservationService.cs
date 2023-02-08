using AutoMapper;
using eCinema.Data;
using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Reservations;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.Resrevations
{
    public class ReservationService: BaseCRUDService<ReservationDto, Reservation,ReservationSearchObject, ReservationInsertDto, ReservationUpdateDto>, IReservationService
    {
        public ReservationService(eCinemaContext context, IMapper mapper):base(context,mapper)
        {

        }
      
        public override IQueryable<Reservation> AddInclude(IQueryable<Reservation> query, ReservationSearchObject search = null)
        {
            var filtered= query.Include(c => c.Customer).Include(a => a.Schedule).ThenInclude(x=>x.Movie);
            return filtered; 
        }

        public override IQueryable<Reservation> AddFilter(IQueryable<Reservation> query, ReservationSearchObject search = null)
        {
            if (!String.IsNullOrEmpty(search.CustomerName))
                query = query.Where(x => x.Customer.FirstName.ToLower().Equals(search.CustomerName.ToLower())
                || x.Customer.LastName.ToLower().Equals(search.CustomerName.ToLower())
                || (x.Customer.FirstName + " " + x.Customer.LastName).ToLower().StartsWith(search.CustomerName.ToLower()));

            if (!String.IsNullOrEmpty(search.Movie))
                query = query.Where(x => x.Schedule.Movie.Title.ToLower().StartsWith(search.Movie.ToLower()));

            return query;
        }
    }
}
