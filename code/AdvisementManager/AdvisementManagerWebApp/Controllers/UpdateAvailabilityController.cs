using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Data;

namespace AdvisementManagerWebApp.Controllers
{
    /// <summary>
    ///   The update avaliability controller for displaying and handling the page to update an advisors availability
    /// </summary>
    public class UpdateAvailabilityController : Controller
    {

        private ApplicationDbContext context { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvisementSessionsController"/> class.
        /// </summary>
        /// <param name="context">The Dbcontext.</param>
        public UpdateAvailabilityController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult UpdateAvailability(string userName)
        {
            var user = this.context.Advisor
                           .FirstOrDefault(loggedInAdvisor => loggedInAdvisor.UserName == userName);
            
            return View();
        }
    }
}
