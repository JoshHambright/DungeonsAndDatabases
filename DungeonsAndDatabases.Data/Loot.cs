using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Data
{
    public class Loot
    {
        [Key]
        public int LootID { get; set; }
        public string Name { get; set; }
        public int ValueInGP { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Campaign))]
        public int CampaignID { get; set; }
        public virtual Campaign Campaign { get; set; }
        
    }
}
