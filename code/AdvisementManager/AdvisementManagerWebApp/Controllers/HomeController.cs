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
    /// <summary>
    ///   The home controllers class
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Student studentModel;

        /// <summary>Initializes a new instance of the <see cref="HomeController" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.studentModel = TestUtilities.GetTestStudent();
        }

        /// <summary>Students the home.</summary>
        /// <returns>
        ///   The current views model
        /// </returns>
        [HttpGet]
        public IActionResult StudentHome()
        {
            return View(this.studentModel);
        }

        /// <summary>Students the home.</summary>
        /// <param name="model">The model.</param>
        /// <returns>
        ///   The current views model
        /// </returns>
        [HttpPost]
        public IActionResult StudentHome(Student model)
        {
            return View(model);
        }

        /// <summary>Errors this instance.</summary>
        /// <returns>
        ///   The errors views model
        /// </returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

