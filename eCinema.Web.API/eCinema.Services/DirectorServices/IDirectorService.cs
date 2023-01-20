using eCinema.Services.CastServices;
using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.DirectorService
{
    public interface IDirectorService:IBaseCRUDService<DirectorDto, CastSearchObject, DirectorDto, DirectorDto>
    {
        List<DirectorDto> Add(int id, List<DirectorDto> insert);
        //void DeleteDirectorsToMovie(int movieId, List<DirectorDto> delete);
        void DeleteDirectorsMovies(DirectorsMoviesDto delete);
        void DeleteDirectorsMovies(List<DirectorsMoviesDto> delete);
    }
}
