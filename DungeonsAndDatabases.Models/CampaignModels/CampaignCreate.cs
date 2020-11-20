using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.Campaign
{
    public class CampaignCreate
    {
        //Model for creating a campaign
        [Required]
        public string CampaignName { get; set; }
        [Required]
        public string GameSystem { get; set; }
        [Required]
        public Guid DmGuid { get; set; }

    }
}
