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
            if (!ModelState.IsValid)
            {
                return View("Add", vm);
            }

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
