using AdvisementManagerWebApp.Data;
using AdvisementManagerWebApp.Models;
using AdvisementManagerWebApp.Temp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Student studentModel;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.studentModel = TestUtilities.GetTestStudent();
        }

        [HttpGet]
        public IActionResult StudentHome()
        {
            return View(this.studentModel);
        }

        [HttpPost]
        public IActionResult StudentHome(Student model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

