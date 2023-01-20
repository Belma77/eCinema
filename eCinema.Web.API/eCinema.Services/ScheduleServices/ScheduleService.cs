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
            return query = query.Include(a => a.Movie);
        }

        public override GetSchedulesDto GetById(int id)
        {
            var query = base.Get();
            var schedule = query.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<GetSchedulesDto>(schedule);

        }

        public override void BeforeInsert(ScheduleInsertDto insert, Schedule entity)
        {
            var movie = _context.Movies.FirstOrDefault(x=>x.Title==insert.Movie.Title);

      
            if (movie != null)
            {
                entity.Movie = movie;
            }

            else
                throw new Exception("Movie not found");

            base.BeforeInsert(insert, entity);
        }

    }
}
