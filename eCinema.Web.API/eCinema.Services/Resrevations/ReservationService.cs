using AutoMapper;
using eCinema.Data;
using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Customer;
using eCInema.Models.Dtos.Reservations;
using eCInema.Models.Dtos.SchedulesSeats;
using eCInema.Models.Entities;
using eCInema.Models.Exceptions;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.Resrevations
{
    public class ReservationService: BaseCRUDService<ReservationDto, Reservation,ReservationSearchObject, ReservationInsertDto, ReservationUpdateDto>, IReservationService
    {
        IHttpContextAccessor _accessor;
        public ReservationService( eCinemaContext context, IMapper mapper, IHttpContextAccessor accessor):base(context,mapper)
        {
            _accessor = accessor;   
        }
      
        public override IQueryable<Reservation> AddInclude(IQueryable<Reservation> query, ReservationSearchObject search = null)
        {
            var filtered= query.Include(c => c.Customer).Include(a => a.Schedule).ThenInclude(x=>x.Movie);
            return filtered; 
        }

        public override IQueryable<Reservation> AddFilter(IQueryable<Reservation> query, ReservationSearchObject search = null)
        {
            if (!String.IsNullOrEmpty(search.CustomerName))
                query = query.Where(x => x.Customer.FirstName.ToLower().Contains(search.CustomerName.ToLower())
                || x.Customer.LastName.ToLower().Contains(search.CustomerName.ToLower())
                || (x.Customer.FirstName + " " + x.Customer.LastName).ToLower().Contains(search.CustomerName.ToLower()));

            if (!String.IsNullOrEmpty(search.Movie))
                query = query.Where(x => x.Schedule.Movie.Title.ToLower().StartsWith(search.Movie.ToLower()));

            return query;
        }

        public override ReservationDto Insert(ReservationInsertDto insert)
        {
            var scheduleDb = _context.Schedules.First(x => x.Id == insert.ScheduleId);
            if (scheduleDb == null)
                throw new  NotFoundException("Schedule not found");

            var scheduleSeats=new List<ScheduleSeat>();
            var seats= _context.ScheduleSeats.Where(x=>x.ScheduleId==insert.ScheduleId).ToList();

            if(scheduleDb.NoAvailableSeats==0)
            {
                throw new BadRequestException("All seats are taken, try reserve another projection");
            }

            foreach (var seat in insert.scheduleSeats)
            {
                var scheduleSeat = _mapper.Map<ScheduleSeat>(seat);
                if (seats.Contains(scheduleSeat))
                {
                        throw new NotFoundException("Seat already reserved");
                }
                scheduleSeat.isTaken = true;
                scheduleDb.NoAvailableSeats--;
                scheduleSeats.Add(scheduleSeat);
            }

            int customerId;
            if (insert.CustomerId == null)
            {
                var user = _accessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;

               var  customer = _context.Customers.FirstOrDefault(x => x.UserName == user);

                if (customer == null)
                    throw new NotFoundException("Customer not found");

                customerId=customer.Id;
            }
            else
            {
                customerId = (int)insert.CustomerId;
            }
            Reservation reservation = new Reservation();
            reservation.CustomerId=customerId;
            reservation.ScheduleId = insert.ScheduleId;
            reservation.Status=eCInema.Models.Enums.ReservationStatusEnum.Booked;
            reservation.NumberOfTickets = insert.NumberOfTickets;
            reservation.Price = insert.NumberOfTickets*scheduleDb.TicketPrice;
            reservation.ScheduleSeat = scheduleSeats;
            reservation.Status = insert.Status;
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return _mapper.Map<ReservationDto>(reservation);

        }
        public List<SalesPerCustomer> GetReservationsByCustomer()
        {
            var reservations = _context.Reservations.Where(x => x.Status == eCInema.Models.Enums.ReservationStatusEnum.Paid).Include(x => x.Customer)  
           .GroupBy(x=>x.Customer).
                Select(x=>new SalesPerCustomer
                {
                    Customer=_mapper.Map<CustomerDto>(x.Key),
                    Sales=x.Sum(y=>y.Price)
                }).
                ToList();
            return reservations;
            
        }
        
    }
}
