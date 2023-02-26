using eCInema.Models.Dtos.Customer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Validators
{
    public class CustomerValidator:AbstractValidator<CustomerInsertDto>
    {
        CustomerValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().NotNull();
            RuleFor(u => u.LastName).NotEmpty().NotNull();
            RuleFor(u => u.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(u => u.Phone).NotEmpty().NotNull().Length(9,9);
            RuleFor(u=>u.Password).NotEmpty().NotNull().Length(6,6);
            RuleFor(u => u.UserName).NotEmpty().NotNull();
        }
    }
}
