﻿using eCInema.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Customer
{
    public class UpdateCustomerDto
    {
        public UpdateCustomerDto() { }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? IdentificationNumber { get; set; }
        public CustomerTypeEnum? CustomerType { get; set; }
    }
}
