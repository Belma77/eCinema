using AutoMapper;
using eCinema.Data;
using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos;
using eCInema.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.CastServices

{
    public class CastService<TDatabase> : ICastService<TDatabase> where TDatabase : class 
    {
        public IMapper _mapper;

        public eCinemaContext _context;

        public CastService(IMapper mapper, eCinemaContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<TDatabase> Add(List<TDatabase> list)
        {
            var context = _context.Set<TDatabase>().ToList();

            foreach(var item in list)
            {
                if(!context.Contains(item))
                {
                    context.Add(item);
                    _context.SaveChanges();
                }
            }
            return context;

        }
        
    }
}
