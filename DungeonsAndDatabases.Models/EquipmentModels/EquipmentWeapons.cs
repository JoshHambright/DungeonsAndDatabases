using DungeonsAndDatabases.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.EquipmentModels
{
    public class EquipmentWeapons
    {
        public string Name { get; set; }
        public string Index { get; set; }
        public string weapon_category { get; set; }
        public string weapon_range { get; set; } //Melee or Ranged
        public string category_range
        {
            get
            {
                return weapon_category
                    + weapon_range;
            }
            set { }
        }
        public object Damage { get; set; }
    }
}
