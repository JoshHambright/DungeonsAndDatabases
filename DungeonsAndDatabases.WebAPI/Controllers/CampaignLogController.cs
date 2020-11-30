using DungeonsAndDatabases.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DungeonsAndDatabases.WebAPI.Controllers
{
    public class CampaignLogController : ApiController
    {
        //Establish DB Connection
        private CampaignLogService CreateCampaignLogService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
        }
    }
}
