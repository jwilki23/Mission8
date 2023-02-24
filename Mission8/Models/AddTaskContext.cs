using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8.Models
{
    public class AddTaskContext : DbContext
    {
        //Constructor
        public AddTaskContext(DbContextOptions<AddTaskContext> options) : base(options)
        {
            //Leave blank for now
        }

        public DbSet<TaskResponse> Responses { get; set; }
        public DbSet<Category> Category { get; set; }


        //Seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData
                (
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" } 
                );

            mb.Entity<TaskResponse>().HasData(

                new TaskResponse
                {
                    InputId = 1,
                    Task = "",
                    DueDate = "",
                    Quadrant = 1,
                    CategoryId = 1,
                    Completed = true,
                },

           

                new TaskResponse
                {
                    InputId = 1,
                    Task = "",
                    DueDate = "",
                    Quadrant = 1,
                    CategoryId = 2,
                    Completed = true,
                },

                new TaskResponse
                {
                    InputId = 1,
                    Task = "",
                    DueDate = "",
                    Quadrant = 1,
                    CategoryId = 2,
                    Completed = true,
                }

                );
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        internal void Update(TaskResponse re)
        {
            throw new NotImplementedException();
        }
    }
}
