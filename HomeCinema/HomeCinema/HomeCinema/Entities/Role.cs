using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Entities
{
    public class Role : IEntityBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}