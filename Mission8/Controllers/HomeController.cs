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

        private TaskInputContext TaskContext { get; set; }

        //Constructor
        public HomeController(TaskInputContext someName)
        {
            TaskContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult TaskList()
        {
            var applications = TaskContext.Responses
                .Include(x => x.Quadrant)
                .OrderBy(x => x.Task)
                .ToList();
            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int inputid)
        {
            ViewBag.Quadrants = TaskContext.Quadrants.ToList();

            var application = TaskContext.Responses.Single(x => x.InputId == inputid);

            return View("TaskForm", application);
        }

        [HttpPost]
        public IActionResult Edit(InputResponse re)
        {
            TaskContext.Update(re);
            TaskContext.SaveChanges();

            return RedirectToAction("TaskList");
        }

        [HttpGet]
        public IActionResult Delete(int inputid)
        {
            var application = TaskContext.Responses.Single(x => x.InputId == inputid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(InputResponse ar)
        {

            TaskContext.Responses.Remove(ar);
            TaskContext.SaveChanges();

            return RedirectToAction("TaskList");
        }

    }
}
