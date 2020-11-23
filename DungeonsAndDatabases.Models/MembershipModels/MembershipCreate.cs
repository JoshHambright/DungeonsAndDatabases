using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.MembershipModels
{
    public class MembershipCreate
    {
        public int CharacterID { get; set; }
        public int CampaignID { get; set; }
    }
}
