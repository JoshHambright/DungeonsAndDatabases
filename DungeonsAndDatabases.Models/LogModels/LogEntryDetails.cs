using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.LogModels
{
    public class LogEntryDetails
    {
        public int LogID { get; set; }
        public string Message { get; set; }
        public int CampaignID { get; set; }
        public string CampaingName { get; set; }
        public string CharacterName { get; set; }
        public Guid PlayerID { get; set; }
        public string PlayerName { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }

    }
}
