using DungeonsAndDatabases.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.EquipmentModels
{
    public class EquipmentCreate
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public int ChararcterID { get; set; }
        public EquipmentType EquipmentType { get; set; }
    }
}
