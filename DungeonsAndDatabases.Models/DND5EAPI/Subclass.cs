﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DND5EAPI
{
    public class Subclass
    {
        public int count { get; set; }
        public List<APIReference> results { get; set; } = new List<APIReference>();
    }
}
