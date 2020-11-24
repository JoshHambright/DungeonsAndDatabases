using DungeonsAndDatabases.Models.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.CampaignModels
{
    public class CampaignListViewWithCharacter
    {
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public string GameSystem { get; set; }
        public string DmName { get; set; }

        public virtual List<CharacterDetail> Characters { get; set; } = new List<CharacterDetail>();
    }
}
