using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HomeCinema.Configurations
{
    public class EntityBaseConfiguration<T> : EntityTypeConfiguration<T> where T : class, Entities.IEntityBase
    {
        public EntityBaseConfiguration()
        {
            HasKey(e => e.ID);
        }
    }
}