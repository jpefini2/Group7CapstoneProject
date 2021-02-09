using Microsoft.AspNetCore.Mvc;
using StudentAdvisementManagerWebApp.Data;
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

        private DAL.LoginDAL loginDAL;

        /// <summary>Initializes a new instance of the <see cref="AccountController" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public AccountController(ApplicationDbContext context)
        {
            this.context = context;
            loginDAL = new DAL.LoginDAL(context);
        }

        /// <summary>
        /// Attempts to log the user in with the provided credentials.
        /// If successful, creates a session cookie and sends the user
        /// to the advisement sessions page. If id == 1, logs the
        /// current user out and deletes their session cookie.
        /// </summary>
        /// <param name="model">The LoginViewModel</param>
        /// <param name="id?">The id indicator.</param>
        /// <returns>The current page.</returns>
        /// <returns>The advisement sessions page.</returns>
        [HttpPost]
        public ActionResult Login([Bind] LoginViewModel model, int? id)
        {
            var username = model.Username;
            var password = model.Password;

            if (id==1 && (Request.Cookies["LoginUser"] != null))
            {
                Response.Cookies.Delete("LoginUser");
                return RedirectToRoute(new { action = "Login", controller = "Account" });
            }

            if (!(String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)))
            {
                bool isValid = this.loginDAL.AttemptLogin(username, password);

                if (!isValid) {
                    ViewBag.Message = "Login failed. Check username or password.";
                } else
                {
                    Response.Cookies.Append("LoginUser", username);
                    return RedirectToRoute(new { action = "StudentHome", controller = "Home" });
                }
            }
            return View(model);
        }

        public RedirectToRouteResult RedirectToCurrentPage()
        {
            ViewBag.Message = "Login failed. Check input fields";
            return RedirectToRoute(new { action = "Login", controller = "Account"});
        }
        
        public IActionResult Login()
        {
            return View();
        }
    }
}

