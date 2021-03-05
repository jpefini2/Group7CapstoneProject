using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AdvisementManagerSharedLibrary.Models;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.DAL;

namespace StudentAdvisementManagerWebApp.Controllers
{
    /// <summary>
    ///   The home controllers class
    /// </summary>
    public class HomeController : Controller
    {
        public ApplicationDbContext context { get; }

        private Student studentModel;

        private readonly StudentDal studentDal = new();

        /// <summary>Initializes a new instance of the <see cref="HomeController" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>Obtains the logged in user from Cookies,
        ///     then loads a StudentHome view to display it.
        /// </summary>
        /// <returns>
        ///   The StudentHome view bound to the logged in student model.
        /// </returns>
        [HttpGet]
        public IActionResult StudentHome()
        {
            this.studentModel = this.studentDal.ObtainStudentWithUsername(Request.Cookies["AdvisementManager.LoginUser"], this.context);
            return View(this.studentModel);
        }

        /// <summary>returns a StudentHome view to display the passed Student.
        /// </summary>
        /// <param name="model">The student model.</param>
        /// <returns>
        ///   The StudentHome view bound to the passed student model.
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
