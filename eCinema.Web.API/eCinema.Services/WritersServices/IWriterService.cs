using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Movie;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.WritersServices
{
    public interface IWriterService
    {
        List<WriterDto> Add(int id, List<WriterDto> insert);
        void DeleteWritersMovies(List<WritersMoviesDto> delete);

    }
}
