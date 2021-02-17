using StudentAdvisementManagerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using StudentAdvisementManagerWebApp.DAL;
using StudentAdvisementManagerWebApp.Data;
using System.Linq;

namespace StudentAdvisementManagerWebApp.Controllers
{
    /// <summary>
    ///   The home controllers class
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;

        private Student studentModel;

        private readonly StudentDal studentDal = new();

        /// <summary>Initializes a new instance of the <see cref="HomeController" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>Students the home.</summary>
        /// <returns>
        ///   The current views model
        /// </returns>
        [HttpGet]
        public IActionResult StudentHome()
        {
            this.studentModel = this.studentDal.ObtainStudentWithUsername(Request.Cookies["AdvisementManager.LoginUser"], this.context);
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
