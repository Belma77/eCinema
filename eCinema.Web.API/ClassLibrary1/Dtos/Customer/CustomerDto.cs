﻿using eCInema.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.Customer
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public CustomerTypeEnum CustomerType { get; set; }
        public string? IdenticiationNumber { get; set; }
        public override string ToString()
        {
            return FirstName + LastName;
        }
    }
}
