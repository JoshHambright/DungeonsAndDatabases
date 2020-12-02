using DungeonsAndDatabases.Models.EquipmentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DND5EAPI
{
    public class Armor : ApiEquipment
    {
        public string armor_category { get; set; }
        public Armor_Class armor_class { get; set; }

        public bool stealth_disadvantage { get; set; }
    }
}
