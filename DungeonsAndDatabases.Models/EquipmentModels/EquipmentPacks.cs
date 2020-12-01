using DungeonsAndDatabases.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.EquipmentModels
{
    public class EquipmentPacks
    {
        public string Name { get; set; }
        public string Index { get; set; }
        public string gear_category { get; set; }
        public List<EquipmentAdventGear> Contents { get; set; } = new List<EquipmentAdventGear>();
    }
}
