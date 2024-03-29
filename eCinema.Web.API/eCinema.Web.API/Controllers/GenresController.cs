﻿using eCinema.Services.GenresServices;
using eCInema.Data.Entities;
using eCInema.Models.Dtos.Genres;
using eCInema.Models.Dtos.Movie;
using eCInema.Models.Enums;
using eCInema.Models.SearchObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthorizeAttribute = eCinema.Web.API.Auth.CustomAuthorizeAttribute;

namespace eCinema.Web.API.Controllers
{
    [Route("Genres")]
    [ApiController]
    [Authorize(UserRole.Admin)]
    public class GenresController : ControllerBase 
    {
        IGenresSerice _service;
        public GenresController(IGenresSerice service) : base()
        {
            _service = service;
        }

        [HttpPost("AddToMovie/{id}")]
        public void AddGenresToMovie(int id, List<GenresDto> insert)
        {
            _service.AddGenresToMovie(id, insert);
        }

        [HttpDelete("FromMovie")]
        public List<MoviesGenresUpdateDto> Delete(List<MoviesGenresUpdateDto> delete)
        {
            return _service.DeleteMoviesGenres(delete);
        }

        [HttpGet]
        public List<GenresDto> Get()
        {
            return  _service.Get();
        }

    }
}
