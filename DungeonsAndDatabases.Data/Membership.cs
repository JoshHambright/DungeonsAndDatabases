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
        [Key, Column(Order = 0)]
        public int CampaignId { get; set; }
        //public virtual Campaign Campaign { get; set; }
        [Key, Column(Order = 1)]
        public int CharacterId { get; set; }
        //public virtual Character Character { get; set; }
    }
}
