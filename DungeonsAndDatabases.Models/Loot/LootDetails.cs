using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.Loot
{
    public class LootDetails
    {
        public int LootID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ValueInGP { get; set; }
        public int CampaignID { get; set; }
    }
}
