using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Movie;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.ProducerServices
{
    public interface IProducerService
    {
        List<ProducerDto> Add(int id, List<ProducerDto> insert);
        void DeleteProducersMovies(List<ProducersMoviesDto> delete);
    }
}
