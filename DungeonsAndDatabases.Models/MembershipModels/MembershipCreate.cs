using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.MembershipModels
{
    public class MembershipCreate
    {
        [Required]
        public int CharacterID { get; set; }
        [Required]
        public int CampaignID { get; set; }
    }
}
