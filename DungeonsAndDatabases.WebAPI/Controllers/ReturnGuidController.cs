using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DungeonsAndDatabases.WebAPI.Controllers
{
    public class ReturnGuidController : ApiController
    {
        // Returns the GUID associated with the Token passed in the header
        public IHttpActionResult GetGuid()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return Ok(userId);
        }
    }
}
