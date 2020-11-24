using DungeonsAndDatabases.Models.CampaignModels;
using DungeonsAndDatabases.Models.CharacterModels;
using DungeonsAndDatabases.Models.MembershipModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.PlayerModels
{
    public class PlayerDetails
    {
        public Guid PlayerID { get; set; }
        public string PlayerName { get; set; }
        public virtual List<CharacterListItem> Characters { get; set; } = new List<CharacterListItem>();
        //public virtual List<MembershipDetails> CharacterCampaign { get; set; } = new List<MembershipDetails>();
        public virtual List<CampaignListViewWithCharacter> CharacterCampaigns { get; set; } = new List<CampaignListViewWithCharacter>();
    }
}