using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Data
{
    public class Membership
    {
        //Joining table to connect Characters to campaigns
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Campaign))]
        public int CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Character))]
        public int CharacterID { get; set; }
        public virtual Character Character { get; set; }
    }
}
