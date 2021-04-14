using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminAdvisementManagerWebApp.Models;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;

namespace AdminAdvisementManagerWebApp.Controllers
{
    public class AdvisorController : Controller
    {
        private ApplicationDbContext context { get; set; }

        public AdvisorController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public IActionResult Advisors()
        {
            AdvisorVM vm = new AdvisorVM {
                Advisors = this.context.Advisor.ToList()
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Add()
        {
            Advisor advisor = new Advisor();
            return View(advisor);
        }

        [HttpPost]
        public IActionResult Submit(Advisor advisor)
        {
            this.context.Login.Add(new User {
                Username = advisor.UserName,
                PasswordHash = advisor.Password
            });
            this.context.SaveChanges();
            Advisor Newadvisor = new Advisor {
                FirstName = advisor.FirstName,
                LastName = advisor.LastName,
                UserName = advisor.UserName,
                Email = advisor.Email,
                IsFacultyAdvisor = advisor.IsFacultyAdvisor
            };

            this.context.Advisor.Add(Newadvisor);
            this.context.SaveChanges();
            return RedirectToAction("Advisors");
        }

    }
}
