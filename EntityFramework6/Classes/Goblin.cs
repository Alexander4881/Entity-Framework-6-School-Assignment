using EntityFramework6.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework6.Classes
{
    [Table("Goblin")]
    class Goblin : BaseEntity, IUniqueIdentifier
    {
        #region Attributes
        private int id;
        private int goblinPower;
        #endregion

        #region Property
        [Key]
        public int ID { get => id; set => id = value; }
        public int GoblinPower { get => goblinPower; set => goblinPower = value; }
        #endregion

        #region Constructor
        public Goblin():base() 
        {
            Type = "Goblin";
        }

        public Goblin(int goblinPower,string name, int health, int attack, int mana) : base(name, health, attack, mana) 
        {
            GoblinPower = goblinPower;
            Type = "Goblin";
        }
        #endregion
    }
}
