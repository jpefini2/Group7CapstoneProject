using AdvisementManagerWebApp.DAL;
using AdvisementManagerWebApp.Data;
using AdvisementManagerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace AdvisementManagerWebApp.Controllers
{
    /// <summary>
    ///   The account controllers class
    /// </summary>
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext context;

        private LoginViewModel loginViewModel = new();

        private LoginDAL loginDAL;

        /// <summary>Initializes a new instance of the <see cref="AccountController" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public AccountController(ApplicationDbContext context)
        {
            this.context = context;
            loginDAL = new LoginDAL(context);
        }

        [HttpPost]
        public IActionResult Login([Bind] LoginViewModel model)
        {
            var u = model.Username;
            var p = model.Password;

            if (!(String.IsNullOrEmpty(u) || String.IsNullOrEmpty(p)))
            {
                bool isValid = this.loginDAL.AttemptLogin(u, p);

                if (!isValid) {
                    ViewBag.Message = "Login failed. Check username or password";
                }
            }
            return View(model);
        }

        public User GetLoggedInUser()
        {
            return this.context.Login.Find(0);
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

