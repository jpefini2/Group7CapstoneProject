using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAdvisementManagerWebApp.Data;
using StudentAdvisementManagerWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace StudentAdvisementManagerWebApp.DAL
{
    /// <summary>
    ///   The student DAL class
    /// </summary>
    public class StudentDal
    {
        private AdvisorDAL advisorDal = new();

        private HoldDAL holdDal = new();

        private AdvisementSessionDAL advisementSessionDal = new ();

        /// <summary>Obtains the students with holds.</summary>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   The current context of students with holds
        /// </returns>
        public IList<Student> ObtainStudentsWithHolds(ApplicationDbContext context)
        {
            return context.Student
                .FromSqlRaw(
                    "SELECT distinct student.studentID, student.firstName, student.lastName, student.email, student.advisorFacultyID, student.advisorGeneralID From Student INNER JOIN Hold ON Hold.studentID = Student.studentID  WHERE isActive = 1;")
                .ToList();
        }

        /// <summary>Obtains the student with the specified id.</summary>
        /// <param name="id">The id.</param>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   The student with the given id.
        /// </returns>
        public Student ObtainStudentWithId(int id, ApplicationDbContext context)
        {
            Student student = context.Student.Find(id);
            student.GeneralAdvisor = this.advisorDal.ObtainAdvisorWithId(student.generalAdvisorId, context);
            student.FacultyAdvisor = this.advisorDal.ObtainAdvisorWithId(student.facultyAdvisorId, context);
            student.Hold = this.holdDal.ObtainHold(id, context);
            student.Meeting = this.advisementSessionDal.ObtainSession(id, context);

            return student;
        }

        public Student ObtainStudentWithUsername(string username, ApplicationDbContext context)
        {
            var student = context.Student.
                FirstOrDefault(loggedInStudent => loggedInStudent.UserName == username);

            student.GeneralAdvisor = this.advisorDal.ObtainAdvisorWithId(student.generalAdvisorId, context);
            student.FacultyAdvisor = this.advisorDal.ObtainAdvisorWithId(student.facultyAdvisorId, context);

            student.Hold = this.holdDal.ObtainHold(student.Id, context);
            student.Meeting = this.advisementSessionDal.ObtainSession(student.Id, context);

            return student;
        }
    }
}