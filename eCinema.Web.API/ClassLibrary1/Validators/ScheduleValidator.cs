using eCInema.Models.Dtos.Schedules;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Validators
{
    public class ScheduleValidator : AbstractValidator<ScheduleInsertDto>
    {
        public ScheduleValidator()
        {
            RuleFor(u => u.Title).NotNull().NotEmpty();
            RuleFor(u => u.NoHall).NotNull().NotEmpty();
            RuleFor(u => u.Date).NotNull().NotEmpty();
            RuleFor(u => u.StartTime).NotNull().NotEmpty();
            RuleFor(u => u.EndTime).NotNull().NotEmpty().GreaterThan(u=>u.StartTime);
        }
    }
}
