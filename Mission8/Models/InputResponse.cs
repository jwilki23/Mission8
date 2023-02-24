using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8.Models
{
    public class InputResponse
    {
        [Key]
        [Required]
        public int InputId { get; set; }

        [Required(ErrorMessage = "Please, Enter task.")]
        public string Task { get; set; }

        [Required(ErrorMessage = "Please, Enter due date.")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Please, Enter Category.")]
        public string Category { get; set; }

        [Required]
        public bool Completed { get; set; }

        //Build Foreign Key Relationship

        //Quadrant
        [Required(ErrorMessage = "Please, select quadrant.")]
        public int QuadrantId { get; set; }
        public Quadrant Quadrant { get; set; }
    }
}