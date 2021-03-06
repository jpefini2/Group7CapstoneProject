﻿using AdvisementManagerDesktopApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerDesktopApp.DAL
{
    /// <summary>The advisement session Dal for managing, editing and pulling sessions from the database.</summary>
    public class AdvisementSessionDal
    {
        /// <summary>Updates the meeting to completed for the passed in student.</summary>
        /// <param name="student">The student.</param>
        public void UpdateMeeting(Student student)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string updateQuery =
                    "UPDATE AdvisementSession SET completed = @completed, notes = @notes WHERE sessionId = @sessionId;";
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@completed", SqlDbType.Bit);
                    cmd.Parameters["@completed"].Value = student.Meeting.Completed;

                    cmd.Parameters.Add("@notes", SqlDbType.VarChar);
                    cmd.Parameters["@notes"].Value = student.Meeting.Notes;

                    cmd.Parameters.Add("@sessionId", SqlDbType.Int);
                    cmd.Parameters["@sessionId"].Value = student.Meeting.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<AdvisementSession> ObtainStudentSessions(Student student)
        {
            List<AdvisementSession> sessions;

            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string selectQuery =
                    "SELECT sessionID, advisorID, studentID, holdID, sessionDate, notes FROM AdvisementSession WHERE holdID = @holdID and completed = 1 and studentID = @studentID";

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add("@holdID", SqlDbType.Int);
                    cmd.Parameters["@holdID"].Value = student.Hold.Id;
                    cmd.Parameters.Add("@studentID", SqlDbType.Int);
                    cmd.Parameters["@studentID"].Value = student.Id;

                    sessions = this.createSessions(cmd);
                }
            }

            return sessions;
        }

        private List<AdvisementSession> createSessions(Microsoft.Data.SqlClient.SqlCommand cmd)
        {
            var sessions = new List<AdvisementSession>();
            using var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                var sessionIdOrdinal = reader.GetOrdinal("sessionID");
                var advisorIdOrdinal = reader.GetOrdinal("advisorID");
                var studentIdOrdinal = reader.GetOrdinal("studentID");
                var holdIdOrdinal = reader.GetOrdinal("holdID");
                var sessionDateOrdinal = reader.GetOrdinal("sessionDate");
                var notesOrdinal = reader.GetOrdinal("notes");

                while (reader.Read())
                {
                    sessions.Add(new AdvisementSession 
                    {
                        Id = reader[sessionIdOrdinal] == DBNull.Value ? 0 : reader.GetInt32(sessionIdOrdinal),
                        AdvisorID = reader[advisorIdOrdinal] == DBNull.Value ? 0 : reader.GetInt32(advisorIdOrdinal),
                        StudentID = reader[studentIdOrdinal] == DBNull.Value ? 0 : reader.GetInt32(studentIdOrdinal),
                        HoldID = reader[holdIdOrdinal] == DBNull.Value ? 0 : reader.GetInt32(holdIdOrdinal),
                        Date = reader[sessionDateOrdinal] == DBNull.Value ? DateTime.MinValue : reader.GetDateTime(sessionDateOrdinal),
                        Notes = reader[notesOrdinal] == DBNull.Value ? null : reader.GetString(notesOrdinal)
                    });
                }
            }

            return sessions;
        }

        /// <summary>Obtains the upcoming sessions for the desired advisor</summary>
        /// <param name="context">The context.</param>
        /// <param name="advisor">The advisor.</param>
        /// <returns>A list of the advisor's upcoming advisement sessions</returns>
        public IList<AdvisementSession> ObtainAdvisorsUpcomingSessions(Advisor advisor)
        {
            List<AdvisementSession> sessions;

            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string selectQuery =
                    "SELECT sessionID, advisorID, studentID, holdID, sessionDate, notes FROM AdvisementSession WHERE advisorID = @advisorID and completed = 0";

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.Add("@advisorID", SqlDbType.Int);
                    cmd.Parameters["@advisorID"].Value = advisor.Id;

                    sessions = this.createSessions(cmd);
                }
            }
            conn.Close();

            var studentDal = new StudentDal();
            var holdDal = new HoldsDal();
            foreach (var session in sessions)
            {
                session.Hold = holdDal.ObtainHoldWithId(session.HoldID);
                session.Student = studentDal.ObtainStudentWithId(session.StudentID);
                session.Student.Meeting = session;
                session.Student.Hold = session.Hold;
                session.Advisor = advisor;
            }

            return sessions;
        }

        public void UpdateAvailability(Advisor advisor, Dictionary<string, List<string>> timeSlots)
        {
            int advisorId = advisor.Id;
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string updateQuery =
                    "INSERT INTO Availability (dayOfTheWeek, timeBegin, timeEnd, advisorID) VALUES (@dayOfTheWeek, @timeBegin, @timeEnd, @advisorID);";
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@advisorID", SqlDbType.VarChar);
                    cmd.Parameters.Add("@dayOfTheWeek", SqlDbType.Int);
                    cmd.Parameters.Add("@timeBegin", SqlDbType.VarChar);
                    cmd.Parameters.Add("@timeEnd", SqlDbType.VarChar);

                    cmd.Parameters["@advisorID"].Value = advisorId;

                    foreach (KeyValuePair<string, List<string>> entry in timeSlots)
                    {
                        var dayInt = 0;

                        if (entry.Key.Equals("Sunday"))
                        {
                            dayInt = 1;
                        }
                        else if (entry.Key.Equals("Monday"))
                        {
                            dayInt = 2;
                        }
                        else if (entry.Key.Equals("Tuesday"))
                        {
                            dayInt = 3;
                        }
                        else if (entry.Key.Equals("Wednesday"))
                        {
                            dayInt = 4;
                        }
                        else if (entry.Key.Equals("Thursday"))
                        {
                            dayInt = 5;
                        }
                        else if (entry.Key.Equals("Friday"))
                        {
                            dayInt = 6;
                        }
                        else if (entry.Key.Equals("Saturday"))
                        {
                            dayInt = 7;
                        }
                        cmd.Parameters["@dayOfTheWeek"].Value = dayInt;

                        foreach (string time in entry.Value)
                        {
                            string timeBegin = time.Split('-')[0];
                            string timeEnd = time.Split('-')[1];
                            cmd.Parameters["@timeBegin"].Value = timeBegin;
                            cmd.Parameters["@timeEnd"].Value = timeEnd;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        /// <summary>Cancels the specified meeting in the database for the advisor.</summary>
        /// <param name="meetingId">The meeting identifier.</param>
        public void CancelMeeting(int meetingId)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string deleteQuery = "DELETE FROM AdvisementSession WHERE sessionID = @sessionID";


                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.Add("@sessionID ", SqlDbType.Int);
                    cmd.Parameters["@sessionID "].Value = meetingId;
                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();
        }
    }
}
