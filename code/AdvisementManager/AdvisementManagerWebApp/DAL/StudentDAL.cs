using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using AdvisementManagerWebApp.Data;
using AdvisementManagerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AdvisementManagerWebApp.DAL
{
    /// <summary>
    ///   The student DAL class
    /// </summary>
    public class StudentDal
    {

        public IList<Student> ObtainStudentsWithHolds(ApplicationDbContext context)
        {
            return context.Student
                .FromSqlRaw(
                    "SELECT distinct student.studentID, student.firstName, student.lastName, student.email From Student INNER JOIN Hold ON Hold.studentID = Student.studentID  WHERE isActive = 1;")
                .ToList();
        }
    }
}