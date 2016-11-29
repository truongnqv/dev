using HomeCinema.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Entities
{
    public class UserRoleConfiguration : EntityBaseConfiguration<UserRole>
    {
        public UserRoleConfiguration()
        {
            Property(ur => ur.UserId).IsRequired();
            Property(ur => ur.RoleId).IsRequired();
        }
    }
}