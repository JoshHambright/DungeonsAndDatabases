using DungeonsAndDatabases.Data;
using DungeonsAndDatabases.Models.MembershipModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.CampaignModels
{
    public class CampaignDetail
    {
        //Model for displaying campaign details
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public string GameSystem { get; set; }
        public Guid DmGuid { get; set; }
        public string DmName { get; set; }
        //public virtual Player  DungeonMaster { get; set; }
        public virtual List<MembershipWithPlayerName> Memberships { get; set; } = new List<MembershipWithPlayerName>();
    }
}
