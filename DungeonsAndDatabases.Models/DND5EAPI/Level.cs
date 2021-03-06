﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDatabases.Models.DND5EAPI
{
    public class Level
    {
        public string index { get; set; }
        public int level { get; set; }
        public int ability_score_bonuses { get; set; }
        public int prof_bonus { get; set; }
        public List<APIReference> feature_choice { get; set; } = new List<APIReference>();
        public List<APIReference> features { get; set; } = new List<APIReference>();
        public Spellcasting Spellcasting { get; set; }
        //public Class_Specific class_Specific { get; set; }
        public APIReference Class { get; set; }
        public string url { get; set; }
    }
}
