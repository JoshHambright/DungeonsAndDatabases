using DungeonsAndDatabases.Models.Campaign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Services
{
    public class CampaignService
    {
        //GUID
        private readonly Guid _userId;

        public CampaignService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCampaign(CampaignCreate model)
        {
            return
        }
    }
}
