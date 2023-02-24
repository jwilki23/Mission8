using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission8.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8.Controllers
{
    public class HomeController : Controller
    {
        private AddTaskContext taskContext { get; set; }
        //Constructor
        public HomeController(AddTaskContext task)
        {
            taskContext = task;
        }
        //method for when you click on index
        public IActionResult Index()
        {
            return View();
        }
        //method for when retrieving new entry page
        [HttpGet]
        public IActionResult AddTask()
        {
            //pulls category data
            ViewBag.Categories = taskContext.Categories.ToList();
            //pulls Quadrant data
            ViewBag.Quadrants = taskContext.Quadrants.ToList();
            return View();
        }

        //method to add task to data base
        [HttpPost]
        public IActionResult AddTask(TaskResponse tr)
        {
            ViewBag.Categories = taskContext.Categories.ToList();
            //pulls Quadrant data
            ViewBag.Quadrants = taskContext.Quadrants.ToList();
            //method to add and save changes to entry if valid data is entered
            if (ModelState.IsValid)
            {
                taskContext.Add(tr);
                taskContext.SaveChanges();
                return View("Index", tr);
            }
            //otherwise returns them back to the page they were on
            else
            {
                return View(tr);
            }

        }
        

        public IActionResult Collection()
        {
            var entries = taskContext.Responses
                .Include(x => x.Quadrant)
                .OrderBy(x => x.Category)
                .ToList();
            return View(entries);
        }
        //method to edit an entry
        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            //pulls category data
            ViewBag.Categories = taskContext.Categories.ToList();
            //pulls Quadrant data
            ViewBag.Quadrants = taskContext.Quadrants.ToList();
            //creates variable holding data for the specified entry
            var response = taskContext.Responses.Single(x => x.TaskId == taskid);
            //returns NewMovies view with data from specified entry
            return View("AddTask", response);
        }
        //Saves the edits to the database
        [HttpPost]
        public IActionResult Edit(TaskResponse blah)
        {
            //method to add and save changes to entry if valid data is entered
            if (ModelState.IsValid)
            {
                taskContext.Add(blah);
                taskContext.SaveChanges();
                return View("Tasks", blah);
            }
            //otherwise returns them back to the page they were on
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            //creates variable holding data for the specified entry
            var response = taskContext.Responses.Single(x => x.TaskId == taskid);
            //returns delete view with data from specified entry
            return View(response);
        }
        [HttpPost]
        public IActionResult Delete(TaskResponse tr)
        {
            //method to delete and save changes to entry if valid data is entered
            taskContext.Responses.Remove(tr);
            taskContext.SaveChanges();
            //redirects back to collection view
            return RedirectToAction("Tasks");
        }

    }
}
