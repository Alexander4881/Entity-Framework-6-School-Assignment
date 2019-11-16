using EntityFramework6.Classes;
using EntityFramework6.DatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework6
{
    class MainMVVM : INotifyPropertyChanged
    {
        #region Attributes
        private List<BaseEntity> baseEntities;
        private BaseEntity baseEntity;
        #endregion

        #region Properties
        public List<BaseEntity> BaseEntities { get => baseEntities; set { baseEntities = value; OnPropertyChanged("BaseEntities"); } }
        public BaseEntity BaseEntity { get => baseEntity; set { baseEntity = value; OnPropertyChanged("BaseEntity"); } }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged; 
        #endregion

        #region Constructor
        public MainMVVM()
        {
            // use the data base
            using (var db = new EntityFrameworkContext())
            {
                Spell fireball = new Spell("Fireball", 12, 10);
                //insert a new BaseEntity
                for (int i = 1; i < 21; i++)
                {
                    BaseEntity baseEntity = new BaseEntity("BaseEntity", 100, 10 + i, 100,fireball);
                    db.BaseEntitys.Add(baseEntity);
                }

                db.SaveChanges();

                BaseEntities = db.BaseEntitys.ToList();
                BaseEntity = BaseEntities[0];
            }
        }
        #endregion

        #region Event Methods
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
