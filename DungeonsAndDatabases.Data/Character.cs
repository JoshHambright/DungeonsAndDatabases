using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Data
{
    public class Character
    {
        [Key]
        public int CharacterID { get; set; } 
        [Required]
        public string CharacterName { get; set; }
        [Required]
        public string Race { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string Level { get; set; }

        public virtual List<Equipment> Inventory { get; set; } = new List<Equipment>();

        public virtual Player Player { get; set; }

        [ForeignKey(nameof(Player))] //Foreign key that will be used to assign character to its player
        public Guid PlayerID { get; set; }


    }
}
