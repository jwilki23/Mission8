using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8.Models
{
    public class TaskResponse
    {
        //makes submissionid the primary key
        [Key]
        [Required]
        public int TaskId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required(ErrorMessage = "Task required")]
        public string Task { get; set; }
        public DateTime DueDate { get; set; }
        [Required(ErrorMessage = "Quadrant required")]
        public int Quadrant { get; set; }
        public bool Completed { get; set; }
    }
}
