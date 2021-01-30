using System;
using System.Data;
using System.Data.SqlClient;
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
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(updateQuery, conn))
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

        /// <summary>Checks for meetings.</summary>
        /// <param name="student">The student.</param>
        /// <returns>
        ///   The found meeting
        /// </returns>
        public AdvisementSession CheckForMeetings(Student student)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();

                const string selectQuery =
                    "SELECT sessionID, completed, stage, sessionDate FROM AdvisementSession WHERE studentID  = @studentID ;";
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add("@studentID ", SqlDbType.Int);
                    cmd.Parameters["@studentID "].Value = student.Id;


                    var meeting = this.CreateMeeting(cmd);
                    
                    return meeting;
                }
            }
        }

        private AdvisementSession CreateMeeting(Microsoft.Data.SqlClient.SqlCommand cmd)
        {
            var meeting = new AdvisementSession();
            using var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                var sessionIdOrdinal = reader.GetOrdinal("sessionID");
                var completedOrdinal = reader.GetOrdinal("completed");
                var stageIdOrdinal = reader.GetOrdinal("stage");
                var sessionDateOrdinal = reader.GetOrdinal("sessionDate");

                while (reader.Read())
                {
                    meeting = new AdvisementSession {
                        Id = reader[sessionIdOrdinal] == DBNull.Value ? 0 : reader.GetInt32(sessionIdOrdinal),
                        Completed = reader[completedOrdinal] != DBNull.Value && reader.GetBoolean(completedOrdinal),
                        Stage = reader[stageIdOrdinal] == DBNull.Value ? 0 : reader.GetInt16(stageIdOrdinal),
                        Date = reader[sessionDateOrdinal] == DBNull.Value
                            ? DateTime.MinValue
                            : reader.GetDateTime(sessionDateOrdinal)
                    };
                }
            }


            return meeting;
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
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(updateQuery, conn))
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
