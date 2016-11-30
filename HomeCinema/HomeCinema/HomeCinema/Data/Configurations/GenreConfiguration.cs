using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeCinema.Configurations;

namespace HomeCinema.Entities
{
    public class GenreConfiguration : EntityBaseConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(g => g.Name).IsRequired().HasMaxLength(50);
        }
    }
}