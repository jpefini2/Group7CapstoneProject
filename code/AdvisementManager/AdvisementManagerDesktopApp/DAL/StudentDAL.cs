﻿using System;
using System.Collections.Generic;
using System.Data;
using AdvisementManagerDesktopApp.Model;
using Microsoft.Data.SqlClient;

namespace AdvisementManagerDesktopApp.DAL
{
    /// <summary>
    ///   The student DAL class
    /// </summary>
    public class StudentDal
    {
        /// <summary>Obtains the students with holds.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public IList<Student> ObtainStudentsWithHolds()
        {
            var students = new List<Student>();

            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string insertQuery =
                    " SELECT Student.studentID, Student.firstName, Student.lastName, Student.email, Student.advisorGeneralID, Student.advisorFacultyID, Hold.holdID, Hold.reason, Hold.dateAdded, Hold.isActive FROM Student INNER JOIN Hold ON Hold.studentID = Student.studentID WHERE isActive = @isActive;";
                using (var cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add("@isActive", SqlDbType.TinyInt);
                    cmd.Parameters["@isActive"].Value = true;

                    appendStudent(cmd, students);

                    return students;
                }

            }
        }

        private static void appendStudent(SqlCommand cmd, ICollection<Student> students)
        {
            using var reader = cmd.ExecuteReader();
            var lnameOrdinal = reader.GetOrdinal("firstName");
            var fnameOrdinal = reader.GetOrdinal("lastName");
            var studentIdOrdinal = reader.GetOrdinal("studentID");
            var emailOrdinal = reader.GetOrdinal("email");
            var holdIdOrdinal = reader.GetOrdinal("holdID");
            var reasonOrdinal = reader.GetOrdinal("reason");
            var dateAddedOrdinal = reader.GetOrdinal("dateAdded");

            while (reader.Read())
            {
                var hold = new Hold {
                    Id = reader[holdIdOrdinal] == DBNull.Value ? 0 : reader.GetInt32(holdIdOrdinal),
                    Reason = reader[reasonOrdinal] == DBNull.Value ? "null" : reader.GetString(reasonOrdinal),
                    Date = reader[dateAddedOrdinal] == DBNull.Value
                        ? DateTime.Now
                        : reader.GetDateTime(dateAddedOrdinal)
                };

                var student = new Student {
                    LastName = reader[lnameOrdinal] == DBNull.Value ? "null" : reader.GetString(lnameOrdinal),
                    FirstName = reader[fnameOrdinal] == DBNull.Value ? "null" : reader.GetString(fnameOrdinal),
                    Id = reader[studentIdOrdinal] == DBNull.Value ? 0 : reader.GetInt32(studentIdOrdinal),
                    Email = reader[emailOrdinal] == DBNull.Value ? "null" : reader.GetString(emailOrdinal),
                    Hold = hold
                };

                students.Add(student);
            }
        }
    }
}