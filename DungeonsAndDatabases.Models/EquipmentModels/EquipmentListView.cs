using DungeonsAndDatabases.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.EquipmentModels
{
    public class EquipmentListView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public  int CharacterID { get; set; }
        public EquipmentType EquipmentType { get; set; }
    }
}
