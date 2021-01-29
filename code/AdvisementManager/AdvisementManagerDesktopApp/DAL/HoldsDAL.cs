using System.Data;
using AdvisementManagerDesktopApp.Model;
using Microsoft.Data.SqlClient;

namespace AdvisementManagerDesktopApp.DAL
{
    /// <summary>
    ///   The Holds DAL class
    /// </summary>
    public class HoldsDal
    {
        /// <summary>Removes the hold.</summary>
        /// <param name="student">The student.</param>
        public void RemoveHold(Student student)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string updateQuery =
                    "UPDATE hold SET isActive = @isActive, reason = @reason WHERE studentID = @studentId and holdID = @holdId;";
                using (var cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@isActive", SqlDbType.Bit);
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

        /// <summary>Approves the faculty advisor meeting.</summary>
        /// <param name="student">The student.</param>
        public void ApproveFacultyAdvisorMeeting(Student student)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string updateQuery =
                    "UPDATE hold SET reason = @reason WHERE holdID = @holdId;";
                using (var cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@reason", SqlDbType.VarChar);
                    cmd.Parameters["@reason"].Value = student.Hold.Reason;

                    cmd.Parameters.Add("@holdId", SqlDbType.Int);
                    cmd.Parameters["@holdId"].Value = student.Hold.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
