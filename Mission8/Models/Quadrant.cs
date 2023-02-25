using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Mission8.Models
{
    public class Quadrant
    {
        [Key]
        [Required]
        public int QuardrantId { get; set; }

        public string QuadrantName { get; set; }
    }
}
