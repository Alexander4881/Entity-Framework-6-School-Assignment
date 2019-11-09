using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework6.Classes
{
    [Table("BaseEntity")]
    class BaseEntity
    {
        [Key]
        public int ID { get; internal set; }
        public string Name { get; internal set; }
        public int Health { get; internal set; }
        public int Attack { get; internal set; }
        public int Mana { get; internal set; }

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
    }
}
