using AdvisementManagerWebApp.DAL;
using AdvisementManagerWebApp.Data;
using AdvisementManagerWebApp.Models;
using AdvisementManagerWebApp.Temp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AdvisementManagerWebApp.Controllers
{
    /// <summary>
    ///   The account controllers class
    /// </summary>
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext context;

        private LoginViewModel loginViewModel = new();
        
        private LoginDAL loginDAL = new();

        /// <summary>Initializes a new instance of the <see cref="AccountController" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public AccountController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult Login([Bind] LoginViewModel model)
        {
            var u = model.Username;
            var p = model.Password;

            if (!(String.IsNullOrEmpty(u) || String.IsNullOrEmpty(p)))
            {
                bool isValid = this.loginDAL.isLoginValid(context, u, p);

                if (isValid) {
                    ViewBag.Message = "Login suceeded.";
                } else
                {
                    ViewBag.Message = "Login failed. Check username or password";
                }
            }
            return View(model);
        }
        
        public IActionResult Login()
        {
            return View();
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

