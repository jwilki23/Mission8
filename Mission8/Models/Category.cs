using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Mission8.Models
{
    public class Category
    {
            [Key]
            [Required]
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
    }
}
