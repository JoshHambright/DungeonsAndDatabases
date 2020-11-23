using DungeonsAndDatabases.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.MembershipModels
{
    public class MembershipDetails
    {
        public int CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }
    }
}
