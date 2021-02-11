using AdvisementManagerDesktopApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerDesktopApp.DAL;

namespace AdvisementManagerDesktopApp.Controller
{
    /// <summary>The advisement session Dal</summary>
    public class AdvisementSessionDal
    {
        /// <summary>Updates the meeting.</summary>
        /// <param name="student">The student.</param>
        public void UpdateMeeting(Student student)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string updateQuery =
                    "UPDATE AdvisementSession SET completed = @completed WHERE sessionId = @sessionId;";
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@completed", SqlDbType.Bit);
                    cmd.Parameters["@completed"].Value = student.Meeting.Completed;

                    cmd.Parameters.Add("@sessionId", SqlDbType.Int);
                    cmd.Parameters["@sessionId"].Value = student.Meeting.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
