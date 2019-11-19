using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework6.Classes
{
    [Table("Mage")]
    class Mage : BaseEntity
    {
        #region Attributes
        private int id;
        private int magePower;
        #endregion

        #region Properties
        [Key]
        public int ID { get => id; set => id = value; }
        public int MagePower { get => magePower; set => magePower = value; }
        #endregion

        #region Constructor
        public Mage() : base() 
        {
            Type = "Mage";
        }

        public Mage(int magePower,string name, int health, int attack, int mana) : base(name, health, attack, mana)
        {
            MagePower = magePower;
            Type = "Mage";
        } 
        #endregion
    }
}
