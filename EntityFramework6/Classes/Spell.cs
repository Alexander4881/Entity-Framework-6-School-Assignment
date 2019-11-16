using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework6.Classes
{
    public class Spell
    {
        #region Attributes
        int id;
        string name;
        int attack;
        int manaDrain; 
        #endregion

        #region Properties
        [Key]
        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Attack { get => attack; set => attack = value; }
        public int ManaDrain { get => manaDrain; set => manaDrain = value; } 

        ICollection<BaseEntity> BaseEntities { get; set; }
        #endregion

        #region Constructor
        public Spell() { }
        public Spell(string name, int attack, int manaDrain)
        {
            Name = name;
            Attack = attack;
            ManaDrain = manaDrain;
        } 
        #endregion
    }
}
