using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework6.Classes
{
    [Table("BaseEntity")]
    public class BaseEntity : INotifyPropertyChanged
    {
        #region Attributes
        private int id;
        private string name;
        private string type;
        private int health;
        private int attack;
        private int mana;
        #endregion

        #region Properties
        [Key]
        public int ID { get => id; set { id = value; } }
        public string Name { get => name; set { name = value; OnPropertyChanged("Name"); } }
        public int Health { get => health; private set { health = value; OnPropertyChanged("Health"); } }
        public int Attack { get => attack; protected set { attack = value; OnPropertyChanged("Attack"); } }
        public int Mana { get => mana; internal set { mana = value; OnPropertyChanged("Mana"); } }
        public string Type { get => type; set => type = value; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        // constructor
        public BaseEntity() { }
        public BaseEntity(string name, int health, int attack, int mana)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Mana = mana;
        }


        #region Methods

        /// <summary>
        /// Method from subtracting health
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage)
        {
            if ((Health - damage) >= 0)
            {
                // subtract damage from health
                Health = 0;
            }
            else if (Health <= 0)
            {
                Health = Health - damage;
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
