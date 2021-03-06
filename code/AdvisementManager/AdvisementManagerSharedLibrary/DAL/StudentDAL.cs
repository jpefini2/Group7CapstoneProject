using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibrary.DAL
{
    /// <summary>
    ///   The student DAL class for managing, updating and pulling information from the student table in the database/context.
    /// </summary>
    public class StudentDal
    {
        private AdvisorDAL advisorDal = new();

        private HoldDAL holdDal = new();

        private AdvisementSessionDAL advisementSessionDal = new();

        public IList<Student> ObtainStudentsWithHolds(ApplicationDbContext context, Advisor user)
        {
            return (from student in context.Student join hold in context.Hold on student.Id equals 
                        hold.StudentId into studentWithHold from hold in studentWithHold where 
                        hold.IsActive && (student.facultyAdvisorId == user.Id || student.generalAdvisorId == user.Id)  
                        select student).ToList();
        }

        /// <summary>Obtains the student with the specified id from the DbContext.</summary>
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
            student.Meeting = this.advisementSessionDal.ObtainLatestIncompleteSessionFromStudent(id, context);

            return student;
        }

        /// <summary>Obtains the student with the specified username.</summary>
        /// <param name="username">The student's username.</param>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   The student with the given username.
        /// </returns>
        public Student ObtainStudentWithUsername(string username, ApplicationDbContext context)
        {
            var student = context.Student.
                FirstOrDefault(loggedInStudent => loggedInStudent.UserName == username);

            student.GeneralAdvisor = this.advisorDal.ObtainAdvisorWithId(student.generalAdvisorId, context);
            student.FacultyAdvisor = this.advisorDal.ObtainAdvisorWithId(student.facultyAdvisorId, context);

            student.Hold = this.holdDal.ObtainHold(student.Id, context);
            student.Meeting = this.advisementSessionDal.ObtainLatestIncompleteSessionFromStudent(student.Id, context);

            return student;
        }
    }
}
