using DungeonsAndDatabases.Models.DND5EAPI;
using DungeonsAndDatabases.Models.EquipmentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.CharacterModels
{
    public class CharacterDetail
    {
        public Guid PlayerID { get; set; }
        public string CharacterName { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string Level { get; set; }

        public Race_Short Race_Details { get; set; }

        public Classes_Short Class_Details { get; set; }
        public List<EquipmentListView> Inventory { get; set; } = new List<EquipmentListView>();

        //public List<string> Inventory;

    }
}
