using AutoMapper;
using eCinema.Data;
using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Schedule;
using eCInema.Models.Entities;
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
            if(!String.IsNullOrEmpty(search.Title))
            {
                query = query.Where(x => x.Movie.Title.StartsWith(search.Title));
            }

            else if(search.Date.HasValue)
            {
                query = query.Where(x => x.Date.Date.Equals(search.Date.Value));
            }    

            else if(search.NoOfHall.HasValue)
                query = query.Where(x => x.Hall.NoOfHall==search.NoOfHall);

            return query;
        }

        public override GetSchedulesDto GetById(int id)
        {
            var schedule = _context.Schedules.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<GetSchedulesDto>(schedule);

        }

        public override GetSchedulesDto Insert(ScheduleInsertDto insert)
        {
            var movie = _context.Movies.FirstOrDefault(x=>x.Title==insert.Title);
            var hall = _context.Halls.FirstOrDefault(x => x.NoOfHall == insert.NoHall);

            if (movie != null)
            {
                insert.MovieId = movie.Id;
            }

            else
                throw new Exception("Movie not found");

            if(hall!=null)
                insert.HallId = hall.Id;

            else
            {
                throw new Exception("Hall not found");

            }

           return base.Insert(insert);
        }

    }
}
