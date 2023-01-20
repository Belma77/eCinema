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

namespace eCinema.Services.WritersServices
{
    public interface IWriterService:IBaseCRUDService<WriterDto, CastSearchObject , WriterDto, WriterDto>
    {
        List<WriterDto> Add(int id, List<WriterDto> insert);
        void DeleteWritersMovies(List<WritersMoviesDto> delete);

    }
}
