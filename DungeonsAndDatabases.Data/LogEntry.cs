using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Data
{
    public class LogEntry
    {
        //Campaign Log entry object
        [Key]
        public int LogID { get; set; }
        public string Message { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        [ForeignKey(nameof(Campaign))]
        public int CampaignID { get; set; }
        public virtual Campaign Campaign { get; set; }
        [ForeignKey(nameof(Player))]
        public Guid PlayerID { get; set; }
        public virtual Player Player { get; set; }
    }
}
