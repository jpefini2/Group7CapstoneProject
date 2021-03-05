using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerWebApp.Data;
using AdvisementManagerWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace AdvisementManagerWebApp.DAL
{
    /// <summary>
    ///   The student DAL class for managing, updating and pulling information from the student table in the database/context.
    /// </summary>
    public class StudentDal
    {
        private AdvisorDAL advisorDal = new();

        private HoldDAL holdDal = new();

        private AdvisementSessionDAL advisementSessionDal = new ();

        /// <summary>Obtains the students with active holds from the DbContext</summary>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   The list of students with active holds
        /// </returns>
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
            student.Meeting = this.advisementSessionDal.ObtainSession(id, context);

            return student;
        }
    }
}