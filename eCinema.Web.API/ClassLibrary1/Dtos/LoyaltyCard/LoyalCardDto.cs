﻿using eCInema.Models.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos.LoyaltyCard
{
    public class LoyalCardDto
    {
        public int CustomerId { get; set; }
        public double price { get; set; }
    }
}
