using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Movie;
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
    public interface IDirectorService
    {
        List<DirectorDto> Add(int id, List<DirectorDto> insert);
        void DeleteDirectorsMovies(List<DirectorsMoviesDto> delete);
    }
}
