using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using AdvisementManagerSharedLibrary.DAL;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;

namespace AdvisementManagerWebApp.Controllers
{
    /// <summary>
    ///   The account controllers class, which handles user authentication.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext context;

        private LoginViewModel loginViewModel = new();

        private LoginDAL loginDAL;

        /// <summary>Initializes a new instance of the <see cref="AccountController" />class.</summary>
        /// <param name="context">The ApplicationDBContext</param>
        public AccountController(ApplicationDbContext context)
        {
            this.context = context;
            loginDAL = new LoginDAL(context);
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

            if (id==1 && (Request.Cookies["AdvisementManager.LoginUser"] != null))
            {
                Response.Cookies.Delete("AdvisementManager.LoginUser");
                Response.Cookies.Delete("AdvisementManager.LoginSession");

                return RedirectToRoute(new { action = "Login", controller = "Account" });
            }

            if (!(String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)))
            {
                String sessionKey = this.loginDAL.AttemptLogin(username, password);

                if (String.IsNullOrEmpty(sessionKey)) {
                    ViewBag.Message = "Login failed. Check username or password.";
                } else
                {                    
                    if (loginDAL.createNewLoginSession(username, sessionKey))
                    {
                        Response.Cookies.Append("AdvisementManager.LoginUser", username);
                        Response.Cookies.Append("AdvisementManager.LoginSession", sessionKey);

                    } else
                    {
                        ViewBag.Message = "Something went wrong trying to create a new login session.";
                        return View(model);
                    }
                    return RedirectToRoute(new { action = "AdvisementSessions", controller = "AdvisementSessions" });
                }
            }
            return View(model);
        }
        /// <summary>
        /// Returns the view back to the user.
        /// </summary>
        /// <returns>the current View.</returns>
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
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

