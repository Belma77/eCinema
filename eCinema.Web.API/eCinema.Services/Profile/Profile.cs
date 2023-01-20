using AutoMapper;
using eCInema.Data.Dtos;
using eCInema.Data.Entities;
using eCInema.Models;
using eCInema.Models.Dtos;
using eCInema.Models.Dtos.Hall;
using eCInema.Models.Dtos.Schedule;
using eCInema.Models.Entities;
using eCInema.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.Profiles
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<MovieInsertDto, Movies>();
            CreateMap<Movies, MovieDetailsDto>();
            CreateMap<Movies, GetMoviesDto>();
            CreateMap<MovieUpdateDto, GetMoviesDto>();
            CreateMap<MovieUpdateDto, Movies>();

            CreateMap<Movies, MovieDto>();
            CreateMap<MovieDetailsDto, Movies>();
            CreateMap<MovieInsertDto, MovieDetailsDto>();
            CreateMap<MovieDto, Movies>();

            CreateMap<Actor, ActorDto>();
            CreateMap<ActorDto, Actor>();
            CreateMap<Actor, ActorUpdateDto>();
            CreateMap<ActorsMovies, ActorsMoviesDto>();
            CreateMap<ActorsMoviesDto, ActorsMovies>();

            CreateMap<MoviesGenres, MoviesGenresDto>();
            CreateMap<MoviesGenresDto, MoviesGenres>();
            CreateMap<MoviesGenresUpdateDto, MoviesGenres>();
            CreateMap<GenresDto, Genres>();
            CreateMap<Genres, GenresDto>();

            CreateMap<Director, DirectorDto>();
            CreateMap<DirectorDto, Director>();
            CreateMap<DirectorsMovies, DirectorsMoviesDto>();
            CreateMap<DirectorsMoviesDto, DirectorsMovies>();


            CreateMap<Writer, WriterDto>();
            CreateMap<WriterDto, Writer>();
            CreateMap<WritersMovies, WritersMoviesDto>();
            CreateMap<WritersMoviesDto, WritersMovies>();

            CreateMap<ProducerDto, Producer>();
            CreateMap<Producer, ProducerDto>();
            CreateMap<ProducersMoviesDto, ProducerMovies>();
            CreateMap<ProducerMovies, ProducersMoviesDto>();

            CreateMap<Schedule, GetSchedulesDto>();
            CreateMap<GetSchedulesDto, Schedule>();
            CreateMap<ScheduleInsertDto, Schedule>();
            CreateMap<ScheduleUpdateDto, Schedule>();

            CreateMap<Schedule, GetSchedulesDto>();
            CreateMap<GetSchedulesDto,Schedule>();

            CreateMap<HallDto, Hall>();
            CreateMap<Hall, HallDto>();

        }

    }
}
