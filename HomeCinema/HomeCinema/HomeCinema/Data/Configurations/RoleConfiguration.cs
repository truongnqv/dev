using HomeCinema.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Entities
{
    public class RoleConfiguration : EntityBaseConfiguration<Role>
    {
        public RoleConfiguration()
        {
            Property(ur => ur.Name).IsRequired().HasMaxLength(50);
        }
    }
}