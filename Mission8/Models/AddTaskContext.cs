using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8.Models 
{
    public class AddTaskContext : DbContext
    {
        //Contructor
        public AddTaskContext(DbContextOptions<AddTaskContext> options) : base(options)
        {

        }

        public DbSet<TaskResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //gives each category of task an assigned id
            mb.Entity<Category>().HasData(
                    new Category { CategoryId = 1, CategoryName = "Home" },
                    new Category { CategoryId = 2, CategoryName = "School" },
                    new Category { CategoryId = 3, CategoryName = "Work" },
                    new Category { CategoryId = 4, CategoryName = "Church" }
            );

            mb.Entity<Quadrant>().HasData(
                    new Quadrant { QuadrantId = 1, QuadrantName = "Important / Urgent" },
                    new Quadrant { QuadrantId = 2, QuadrantName = "Important / Not Urgent" },
                    new Quadrant { QuadrantId = 3, QuadrantName = "Not Important / Urgent" },
                    new Quadrant { QuadrantId = 4, QuadrantName = "Not Important / Not Urgent" }
            );

            //seeds the database with base entries
            mb.Entity<TaskResponse>().HasData(

                new TaskResponse
                {
                    TaskId = 1,
                    CategoryId = 2,
                    Task = "Mission #8 Project",
                    DueDate = new DateTime(2023, 2, 24, 11, 59, 59),
                    QuadrantId = 1,
                    Completed = false
                },
                   new TaskResponse
                   {
                       TaskId = 2,
                       CategoryId = 4,
                       Task = "Write a talk",
                       DueDate = new DateTime(2023, 2, 26, 11, 30, 00),
                       QuadrantId = 2,
                       Completed = false
                   },
                      new TaskResponse
                      {
                          TaskId = 3,
                          CategoryId = 1,
                          Task = "Do my laundry",
                          DueDate = new DateTime(2023, 2, 27, 6, 00, 00),
                          QuadrantId = 4,
                          Completed = false
                      }
            );
        }
    }
}
