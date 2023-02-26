using eCInema.Models.Dtos.LoyaltyCard;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Validators
{
    public class LoyalClubValidator:AbstractValidator<LoyalCardInsertDto>
    {
        LoyalClubValidator()
        {
            RuleFor(u => u.CustomerId).NotNull();
            RuleFor(u => u.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(u => u.Phone).NotNull().NotEmpty().Length(9,9);
            RuleFor(u => u.City).NotEmpty().NotNull();
            RuleFor(u => u.FirstName).NotNull().NotEmpty();
            RuleFor(u => u.LastName).NotNull().NotEmpty();
            RuleFor(u => u.IdentificationNumber).NotNull().NotEmpty();

        }
    }
}
