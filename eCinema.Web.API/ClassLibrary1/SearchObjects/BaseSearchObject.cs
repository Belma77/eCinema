﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.SearchObjects
{
    public class BaseSearchObject
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
}
