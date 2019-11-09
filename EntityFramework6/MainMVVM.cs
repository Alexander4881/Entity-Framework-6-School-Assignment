using EntityFramework6.Classes;
using EntityFramework6.DatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework6
{
    class MainMVVM
    {
        // constructor
        public MainMVVM()
        {
            // use the data base
            using (var db = new EntityFrameworkContext())
            {
                // insert a new BaseEntity 
                BaseEntity baseEntity = new BaseEntity("BaseEntity", 100, 10,100);

                db.BaseEntitys.Add(baseEntity);
                db.SaveChanges();
            }
        }
    }
}
