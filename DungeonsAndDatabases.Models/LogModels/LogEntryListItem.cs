using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.LogModels
{
    public class LogEntryListItem
    {
        public int LogID { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; } 
        public int CampaignID { get; set; }
        public string CampaignName { get; set; }
        public string Message { get; set; }
    }
}
