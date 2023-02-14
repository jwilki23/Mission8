﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Mission8.Models
{
    public class Quadrant
    {
            [Key]
            [Required]
            public int QuadrantId { get; set; }
            public string QuadrantName { get; set; }
    }
}
