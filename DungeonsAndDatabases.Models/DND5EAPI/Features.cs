﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DND5EAPI
{
    public class Features
    {
        public int Count { get; set; }
        public List<APIReference> results { get; set; } = new List<APIReference>();
    }
}
