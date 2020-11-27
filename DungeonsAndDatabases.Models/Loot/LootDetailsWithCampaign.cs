using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.Loot
{
    public class LootDetailsWithCampaign
    {
        public int LootID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double ValueInGP { get; set; }
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public string DMName { get; set; }

    }
}
