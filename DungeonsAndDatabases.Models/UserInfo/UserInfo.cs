using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.UserInfo
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public Guid UserId { get; set; }
        public string PlayerName { get; set; }
    }
}
