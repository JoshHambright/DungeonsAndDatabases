using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Data
{
    public enum EquipmentType {Equipment=1, MagicItem }
    public class Equipment
    {
        [Key]
        public int ID { get; set; } // Equipment ID
        public string Name { get; set; } // Equipment name (if corresponding to classes found in the open DND5E API will populate in Detail View)
        public string Notes { get; set; } // Any custom notes the user wants to store about the equipment item
        public virtual Character Character { get; set; } // Lazy loaded character that poses this equipment Item
        public EquipmentType EquipmentType { get; set; } // Set to allow the detail view to pull the right data from the DND5eAPI
        [ForeignKey(nameof(Character))]
        public int CharacterID { get; set; }        // Character ID of the owner of this item

    }
}
