using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8.Models
{
    public class TaskResponse
    {
        [Key]
        [Required]
        public int InputId { get; set; }

        [Required(ErrorMessage = "Please, Enter task.")]
        public string Task { get; set; }

        [Required(ErrorMessage = "Please, Enter due date.")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Please, Enter quadrant.")]
        public string Quadrant { get; set; }

        [Required]
        public bool Completed { get; set; }

        //Build Foreign Key Relationship

        //Category
        [Required(ErrorMessage = "Please, select category.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}