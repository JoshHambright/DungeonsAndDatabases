using DungeonsAndDatabases.Data;
using DungeonsAndDatabases.Models.DND5EAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.EquipmentModels
{
    public class EquipmentDetails
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public int CharacterID { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public ApiEquipment  DND5EAPI_Info { get; set; }
    }
}
