﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.Loot
{
    public class LootCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int  ValueInGP { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CampaignID { get; set; }
    }
}
