using AutoMapper;
using eCinema.Data;
using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Schedules;
using eCInema.Models.Dtos.SchedulesSeats;
using eCInema.Models.Entities;
using eCInema.Models.Exceptions;
using eCInema.Models.SearchObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.ScheduleServices
{
    public class ScheduleService:BaseCRUDService<GetSchedulesDto, Schedule, ScheduleSearchObject, ScheduleInsertDto, ScheduleUpdateDto>, IScheduleService
    {
        public ScheduleService(eCinemaContext context, IMapper mapper):base(context, mapper)
        {

        }

        public override IQueryable<Schedule> AddInclude(IQueryable<Schedule> query, ScheduleSearchObject searchObject = null)
        {
            return query = query.Include(a => a.Movie).Include(x=>x.Hall);
        }

        public override IQueryable<Schedule> AddFilter(IQueryable<Schedule> query, ScheduleSearchObject search = null)
        {
            if (!String.IsNullOrEmpty(search.Title))
            {
                query = query.Where(x => x.Movie.Title.ToLower().Contains(search.Title.ToLower()));
            }

            if (search.Date.HasValue)
            {
                query = query.Where(x => x.Date.Date.Equals(search.Date.Value.Date));
            }
            if (search.MovieId != null)
            {
                query = query.Where(x => x.MovieId == search.MovieId);
            }

            if (!string.IsNullOrEmpty(search.StartTime))
            {
                
                var filter = query.AsEnumerable().Where(x => x.StartTime.ToShortTimeString().Equals(search.StartTime));
                query = filter.AsQueryable();
            }

            if (!string.IsNullOrEmpty(search.DayOfWeek))
            {
                var filter = query.AsEnumerable().Where(x => x.Date.DayOfWeek.ToString().Equals(search.DayOfWeek)).Distinct();
                query=filter.AsQueryable();     
            }

            return query;
        }

        public override GetSchedulesDto GetById(int id)
        {
            var schedule = _context.Schedules
                .Include(x => x.Movie).
            Include(y => y.Hall).ThenInclude(y => y.Seats).Include(x => x.ScheduleSeats)
            .FirstOrDefault(x => x.Id == id);

            if (schedule == null)
                throw new NotFoundException("Schedule not found");

            return _mapper.Map<GetSchedulesDto>(schedule);
        }
        public override List<GetSchedulesDto> Delete(int id)
        {
            var reservations = _context.Reservations.Where(x => x.ScheduleId == id);
            var schedule = _context.Schedules.Find(id);
            var seats = _context.ScheduleSeats.Where(x => x.ScheduleId == id);
            if (schedule == null||reservations==null||seats==null)
            {
                throw new NotFoundException("Not found");
            }
            _context.ScheduleSeats.RemoveRange(seats);
            _context.Reservations.RemoveRange(reservations);
            _context.Schedules.Remove(schedule);

            _context.SaveChanges();
            var list = _context.Schedules.ToList();
            return _mapper.Map<List<GetSchedulesDto>>(list);
        }
        public GetSchedulesDto GetSeats(int id)
        {
            var schedule = _context.Schedules.
           Include(x => x.Movie).Include(y => y.Hall).ThenInclude(y => y.Seats).Include(x => x.ScheduleSeats);
            var result = schedule.FirstOrDefault(x => x.Id == id);

            if (result == null)
                throw new NotFoundException("Schedule not found");

            return _mapper.Map<GetSchedulesDto>(result);
        }
        public List<GetSchedulesDto> GetDistinct()
        {
            var schedules=_context.Schedules.Include(x=>x.Movie).ToList();
            var result = schedules.DistinctBy(x => x.Movie.Title).ToList();
            return _mapper.Map<List<GetSchedulesDto>>(result);
        }
       
        public override void BeforeInsert(ScheduleInsertDto insert, Schedule schedule)
        {
            var movie = _context.Movies.FirstOrDefault(x=>x.Title==insert.Title);
            var hall = _context.Halls.FirstOrDefault(x => x.NoOfHall == insert.NoHall);

            if (movie != null)
            {
                schedule.MovieId = movie.Id;
            }

            else
                throw new NotFoundException("Movie not found");

            if (hall != null)
            {
                schedule.HallId = hall.Id;
            }
            else
            {
                throw new NotFoundException("Hall not found");
            }           
        }

    }
}
