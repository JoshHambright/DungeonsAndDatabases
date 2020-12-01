using DungeonsAndDatabases.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.EquipmentModels
{
    public class EquipmentArmor 
    {
        public string Name { get; set; }
        public string Index { get; set; }
        public string armor_category { get; set; }
        public Armor_Class armor_class { get; set; }

        public bool stealth_disadvantage { get; set; }
    }
}
