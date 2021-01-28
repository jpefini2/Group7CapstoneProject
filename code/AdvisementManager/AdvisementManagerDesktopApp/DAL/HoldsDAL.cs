using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerDesktopApp.Model;
using Microsoft.Data.SqlClient;

namespace AdvisementManagerDesktopApp.DAL
{
    class HoldsDal
    {
        public void RemoveHold(Student student)
        {
            var conn = DBConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string updateQuery =
                    "UPDATE hold SET `isActive` = @isActive and `reason` = @reason WHERE `studentID = @studentId and `holdID` = @holdId;";
                using (var cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@isActive", SqlDbType.TinyInt);
                    cmd.Parameters["@isActive"].Value = student.Hold.IsActive;

                    cmd.Parameters.Add("@reason", SqlDbType.VarChar);
                    cmd.Parameters["@reason"].Value = student.Hold.Reason;

                    cmd.Parameters.Add("@studentId", SqlDbType.Int);
                    cmd.Parameters["@studentId"].Value = student.Id;

                    cmd.Parameters.Add("@holdId", SqlDbType.Int);
                    cmd.Parameters["@holdId"].Value = student.Hold.Id;

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void ApproveFacultyAdvisorMeeting(Student student)
        {
            var conn = DBConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string updateQuery =
                    "UPDATE hold SET `reason` = @reason WHERE `studentID = @studentId and `holdID` = @holdId;";
                using (var cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@reason", SqlDbType.VarChar);
                    cmd.Parameters["@reason"].Value = student.Hold.Reason;

                    cmd.Parameters.Add("@studentId", SqlDbType.Int);
                    cmd.Parameters["@studentId"].Value = student.Id;

                    cmd.Parameters.Add("@holdId", SqlDbType.Int);
                    cmd.Parameters["@holdId"].Value = student.Hold.Id;
                }
            }
        }
    }
}
