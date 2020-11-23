using DungeonsAndDatabases.Data;
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
<<<<<<< HEAD:DungeonsAndDatabases.Models/CampaignModels/CampaignDetail.cs
        //public virtual Player DungeonMaster { get; set; }
        //public virtual List<CharacterListItems> Memberships = new List<CharacterListItems>();
        
=======
        //public virtual Player  DungeonMaster { get; set; }
        //public virtual List<Membership> Memberships = new List<Membership>();
>>>>>>> 12b5ec7 (Character service and controller):DungeonsAndDatabases.Models/Campaign/CampaignDetail.cs
    }
}
