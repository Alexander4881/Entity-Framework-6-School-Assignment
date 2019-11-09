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
        #endregion

        #region Properties
        public List<BaseEntity> BaseEntities { get => baseEntities; set { baseEntities = value; OnPropertyChanged("BaseEntities"); } }
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
                for (int i = 1; i < 21; i++)
                {
                    BaseEntity baseEntity = new BaseEntity("BaseEntity", 100, 10 + i, 100);
                    db.BaseEntitys.Add(baseEntity);
                }

                db.SaveChanges();

                BaseEntities = db.BaseEntitys.ToList();
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
