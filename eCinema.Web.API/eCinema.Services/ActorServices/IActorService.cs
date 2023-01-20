using eCinema.Services.CastServices;
using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.ActorService
{
    public interface IActorService:IBaseCRUDService<ActorDto, CastSearchObject, ActorDto, ActorDto>
    {
        List<ActorDto> Add(int id, List<ActorDto> insert);
        void DeleteActorsMovies(List<ActorsMoviesDto> delete);
    }
}
