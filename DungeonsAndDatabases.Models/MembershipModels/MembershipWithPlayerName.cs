using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.MembershipModels
{
    public class MembershipWithPlayerName
    {
        public int CampaignId { get; set; }
        public virtual string CampaignName { get; set; }
        public int CharacterId { get; set; }
        public virtual string CharacterName { get; set; }
        public virtual string PlayerName { get; set; }
    }
}
