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
        public int CharacterID { get; set; }  //Character ID
        [Required]
        public string CharacterName { get; set; } // Character Name
        [Required]
        public string Race { get; set; } // Character Race (if corresponding to classes found in the open DND5E API will populate in Detail View)
        [Required]
        public string Class { get; set; } //Character Class (if corresponding to classes found in the open DND5E API will populate in Detail View)
        [Required]
        public string Level { get; set; } //Characters current level

        public virtual List<Equipment> Inventory { get; set; } = new List<Equipment>(); // Lazy Loaded list of equipment in your inventory

        public virtual Player Player { get; set; } // Lazy Loaded player who owns this character

        [ForeignKey(nameof(Player))] //Foreign key that will be used to assign character to its player
        public Guid PlayerID { get; set; } //GUID of the player/user that owns this character


    }
}
