﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Entities
{
    public class Error : IEntityBase
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateCreated { get; set; }
    }
}