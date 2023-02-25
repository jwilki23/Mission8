using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8.Models
{
    public class TaskInputContext : DbContext
    {
        //Constructor
        public TaskInputContext(DbContextOptions<TaskInputContext> options) : base(options)
        {
            //Leave blank for now
        }

        public DbSet<InputResponse> Responses { get; set; }
        public DbSet<Quadrant> Quadrants { get; set; }


        //Seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Quadrant>().HasData
                (
                new Quadrant { QuadrantId = 1, QuadrantName = "Important / Urgent" },
                new Quadrant { QuadrantId = 2, QuadrantName = "Important / Not Urgent" },
                new Quadrant { QuadrantId = 3, QuadrantName = "Not Important / Urgent" },
                new Quadrant { QuadrantId = 4, QuadrantName = "Not Important / Not Urgent" } 
                );


            mb.Entity<InputResponse>().HasData(

                new InputResponse
                {
                    InputId = 1,
                    Task = "",
                    DueDate = "",
                    QuadrantId = 1,
                    Category = "",
                    Completed = true,
                },

           

                new InputResponse
                {
                    InputId = 1,
                    Task = "",
                    DueDate = "",
                    QuadrantId = 1,
                    Category = "",
                    Completed = true,
                },

                new InputResponse
                {
                    InputId = 1,
                    Task = "",
                    DueDate = "",
                    QuadrantId = 1,
                    Category = "",
                    Completed = true,
                }

                );
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        internal void Update(InputResponse re)
        {
            throw new NotImplementedException();
        }
    }
}
