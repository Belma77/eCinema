using eCInema.Models.Dtos.Reservations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Validators
{
    public class ReservationValidator:AbstractValidator<ReservationInsertDto>
    {
        ReservationValidator()
        {
            RuleFor(u => u.CustomerId).NotEmpty().NotNull();
            RuleFor(u => u.NumberOfTickets).NotEmpty().NotNull();
            RuleFor(u => u.ScheduleId).NotEmpty().NotNull();
            RuleFor(u => u.Status).NotEmpty().NotNull();
            RuleFor(u => u.scheduleSeats).NotEmpty().NotNull();

        }
    }
}
