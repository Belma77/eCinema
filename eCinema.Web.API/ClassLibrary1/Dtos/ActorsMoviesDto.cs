﻿using eCInema.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCInema.Models.Dtos
{
    public class ActorsMoviesDto/*:CastMoviesDto<ActorDto>*/
    {
        public ActorDto? Actor { get; set; }
        public int MovieId { get; set; }
    }
}
