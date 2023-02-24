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

        private AddTaskContext AddTaskContext { get; set; }

        //Constructor
        public HomeController(AddTaskContext someName)
        {
            TaskContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult TaskList()
        {
            var applications = AddTaskContext.Responses
                .Include(x => x.Quadrant)
                .OrderBy(x => x.Task)
                .ToList();
            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int inputid)
        {
            ViewBag.Quadrants = Models.AddTaskContext.Category.ToList();

            var application = Models.AddTaskContext.Responses.Single(x => x.InputId == inputid);

            return View("TaskForm", application);
        }

        [HttpPost]
        public IActionResult Edit(TaskResponse re)
        {
            Models.AddTaskContext.Update(re);
            Models.AddTaskContext.SaveChanges();

            return RedirectToAction("TaskList");
        }

        [HttpGet]
        public IActionResult Delete(int inputid)
        {
            var application = Models.AddTaskContext.Responses.Single(x => x.InputId == inputid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(TaskResponse ar)
        {

            Models.AddTaskContext.Responses.Remove(ar);
            Models.AddTaskContext.SaveChanges();

            return RedirectToAction("TaskList");
        }

    }
}
