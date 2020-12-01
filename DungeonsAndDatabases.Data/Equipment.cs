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
        public int ID { get; set; }
        public string Name { get; set; } 
        public string Notes { get; set; }
        public virtual Character Character { get; set; }
        public EquipmentType EquipmentType { get; set; }

        [ForeignKey(nameof(Character))]
        public int CharacterID { get; set; }
    }
}
