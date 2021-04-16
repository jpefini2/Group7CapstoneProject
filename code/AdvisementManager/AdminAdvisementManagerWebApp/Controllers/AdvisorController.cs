using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminAdvisementManagerWebApp.Models;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var vm = new AddAdvisorVM {
                NewAdvisor = advisor,
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Submit(AddAdvisorVM vm)
        {
            bool dbHasMatchingEmail = this.context.Advisor.Any(a => a.Email == vm.NewAdvisor.Email);
            bool dbHasMatchingUsername = this.context.Login.Any(l => l.Username == vm.NewAdvisor.UserName);

            if (dbHasMatchingEmail)
                ModelState.AddModelError("", "The provided email address is already registered with an Advisor.");
            
            if (dbHasMatchingUsername)
                ModelState.AddModelError("", "That username is taken.");

            if (!ModelState.IsValid)
                return View("Add", vm);

            this.context.Login.Add(new User {
                Username = vm.NewAdvisor.UserName,
                PasswordHash = vm.NewAdvisor.Password
            });

            this.context.SaveChanges();
            this.context.Advisor.Add(vm.NewAdvisor);
            this.context.SaveChanges();
            return RedirectToAction("Advisors");
        }

    }
}
