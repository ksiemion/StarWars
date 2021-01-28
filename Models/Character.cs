﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class Character
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Episode> Episodes { get; set; } = new List<Episode>();
        public List<Character> Friends { get; set; } = new List<Character>();
        public string Planet { get; set; }
    }
}
