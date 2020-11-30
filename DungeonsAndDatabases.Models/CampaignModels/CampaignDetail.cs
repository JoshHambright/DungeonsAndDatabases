using DungeonsAndDatabases.Data;
using DungeonsAndDatabases.Models.Loot;
using DungeonsAndDatabases.Models.MembershipModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.CampaignModels
{
    public class CampaignDetail
    {
        //Model for displaying campaign details
        [Display(Name = "Campaign ID")]
        public int CampaignID { get; set; }
        [Display(Name = "Campaign Name")]
        public string CampaignName { get; set; }
        [Display(Name = "Campaign Game System")]
        public string GameSystem { get; set; }
        [Display(Name = "Dungeon Master ID")]
        public Guid DmGuid { get; set; }
        [Display(Name = "Dungeon Master Name")]
        public string DmName { get; set; }
        //public virtual Player  DungeonMaster { get; set; }
        [Display(Name = "Members")]
        public virtual List<MembershipWithPlayerName> Memberships { get; set; } = new List<MembershipWithPlayerName>();
        [Display(Name = "Campaign Loot")]
        public virtual List<LootDetails> CampaignLoot { get; set; } = new List<LootDetails>();
    }
}
