using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminAdvisementManagerWebApp.Models;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminAdvisementManagerWebApp.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext context { get; set; }

        public StudentController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Students()
        {
            var vm = new AllStudentsVM {
                Students = this.context.Student.ToList()
            };

            foreach (var student in vm.Students)
            {
                student.FacultyAdvisor = this.context.Advisor.Find(student.facultyAdvisorId);
                student.GeneralAdvisor = this.context.Advisor.Find(student.generalAdvisorId);
            }

            return View(vm);
        }

        public IActionResult Add()
        {
            var facultyAdvisors =
                (from advisor in this.context.Advisor where advisor.IsFacultyAdvisor == true select advisor).ToList();
            var generalAdvisors =
                (from advisor in this.context.Advisor where advisor.IsFacultyAdvisor == false select advisor).ToList();
            
            var vm = new AddStudentVM {
                NewStudent = new Student(),
                FacultyAdvisors = new SelectList(facultyAdvisors, "Id", "FullName"),
                GeneralAdvisors = new SelectList(generalAdvisors, "Id", "FullName")
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Submit(AddStudentVM vm)
        {
            bool dbHasMatchingEmail = this.context.Student.Any(a => a.Email == vm.NewStudent.Email);
            bool dbHasMatchingUsername = this.context.Login.Any(l => l.Username == vm.NewStudent.UserName);

            if (dbHasMatchingEmail)
                ModelState.AddModelError("", "The provided email address is already registered with a Student.");

            if (dbHasMatchingUsername)
                ModelState.AddModelError("", "That username is taken.");
            
            if (!ModelState.IsValid)
            {
                var facultyAdvisors =
                    (from advisor in this.context.Advisor where advisor.IsFacultyAdvisor == true select advisor).ToList();
                var generalAdvisors =
                    (from advisor in this.context.Advisor where advisor.IsFacultyAdvisor == false select advisor).ToList();

                vm.FacultyAdvisors = new SelectList(facultyAdvisors, "Id", "FullName");
                vm.GeneralAdvisors = new SelectList(generalAdvisors, "Id", "FullName");
                return View("Add", vm);
            }

            this.context.Login.Add(new User
            {
                Username = vm.NewStudent.UserName,
                PasswordHash = vm.NewStudent.Password
            });
            this.context.SaveChanges();
            
            this.context.Add(vm.NewStudent);
            this.context.SaveChanges();

            return RedirectToAction("Students");
        }

        public IActionResult Edit(int studentId)
        {
            var facultyAdvisors =
                (from advisor in this.context.Advisor where advisor.IsFacultyAdvisor == true select advisor).ToList();
            var generalAdvisors =
                (from advisor in this.context.Advisor where advisor.IsFacultyAdvisor == false select advisor).ToList();

            var student = this.context.Student.Find(studentId);
            student.FacultyAdvisor = this.context.Advisor.Find(student.facultyAdvisorId);
            student.GeneralAdvisor = this.context.Advisor.Find(student.generalAdvisorId);

            var vm = new AddStudentVM {
                NewStudent = student,
                FacultyAdvisors = new SelectList(facultyAdvisors, "Id", "FullName"),
                GeneralAdvisors = new SelectList(generalAdvisors, "Id", "FullName"),
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(AddStudentVM vm)
        {
            var student = this.context.Student.Find(vm.NewStudent.Id);
            student.facultyAdvisorId = vm.NewStudent.facultyAdvisorId;
            student.generalAdvisorId = vm.NewStudent.generalAdvisorId;
            this.context.SaveChanges();
            return RedirectToAction("Students");
        }
    }
}
