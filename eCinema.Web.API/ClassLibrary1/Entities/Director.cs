﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Entities
{
    public class Director:Cast
    {
        List<DirectorsMovies>? DirectorsMovies { get; set; } 
    }
}
