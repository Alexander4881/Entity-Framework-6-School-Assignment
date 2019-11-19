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
                //insert a new BaseEntity
                for (int i = 1; i < 2; i++)
                {
                    Mage mage = new Mage(100 + i,"Mage" + i, 100, 10 + i, 100);
                    db.BaseEntitys.Add(mage);

                    Goblin goblin = new Goblin(100 + i, "Goblin" + i, 100, 10 + i, 100);
                    db.BaseEntitys.Add(goblin);
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
