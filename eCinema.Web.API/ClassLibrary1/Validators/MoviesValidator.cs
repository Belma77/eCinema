using eCInema.Models.Dtos.Movie;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Validators
{
    public class MoviesValidator:AbstractValidator<MovieInsertDto>
    {
        MoviesValidator()
        {
            RuleFor(u => u.Title).NotNull().NotEmpty();
            RuleFor(u => u.ReleaseYear).NotNull().NotEmpty();
            RuleFor(u => u.Synopsis).NotNull().NotEmpty();
            RuleFor(u => u.Country).NotNull().NotEmpty();
            RuleFor(u => u.Duration).NotNull().NotEmpty();
            RuleFor(u => u.Genres).NotNull().NotEmpty();
            RuleFor(u => u.Poster).NotNull().NotEmpty();
            RuleFor(u => u.Actors).NotNull().NotEmpty();
            RuleFor(u => u.Directors).NotNull().NotEmpty();
            RuleFor(u => u.Producers).NotNull().NotEmpty();
            RuleFor(u => u.Writers).NotNull().NotEmpty();

        }
    }
}
