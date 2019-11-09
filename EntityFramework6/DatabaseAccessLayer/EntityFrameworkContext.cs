using EntityFramework6.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework6.DatabaseAccessLayer
{
    class EntityFrameworkContext:DbContext
    {
        public EntityFrameworkContext():base("EntityFramework6")
        {
            Database.SetInitializer<EntityFrameworkContext>(new DropCreateDatabaseIfModelChanges<EntityFrameworkContext>());
        }

        public DbSet<BaseEntity> BaseEntitys { get; set; }
    }
}
