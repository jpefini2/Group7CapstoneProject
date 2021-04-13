using AdvisementManagerSharedLibrary.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace AdvisementManagerDesktopApp.DAL
{
    class NotificationDal
    {
        /// <summary>
        /// Adds a new notification to the database.
        /// </summary>
        /// <param name="studentID">The studentID of the student being notified.</param>
        /// <param name="advisorID">The advisorID of the advisor being notified.</param>
        /// <param name="message">The message that will be sent to the student and advisor.</param>
        public void AddNotification(int studentID, int advisorID, string message)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string updateQuery =
                    "INSERT INTO Notification (studentID, advisorID, notifMessage, isRemovedFromAdvisor, isRemovedFromStudent) VALUES (@studentID, @advisorID, @notifMessage, @isRemovedFromAdvisor, @isRemovedFromStudent);";

                using (var cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@advisorID", SqlDbType.Int);
                    cmd.Parameters.Add("@studentID", SqlDbType.Int);
                    cmd.Parameters.Add("@notifMessage", SqlDbType.VarChar);
                    cmd.Parameters.Add("@isRemovedFromAdvisor", SqlDbType.Bit);
                    cmd.Parameters.Add("@isRemovedFromStudent", SqlDbType.Bit);

                    cmd.Parameters["@studentID"].Value = studentID;
                    cmd.Parameters["@advisorID"].Value = advisorID;
                    cmd.Parameters["@notifMessage"].Value = message;
                    cmd.Parameters["@isRemovedFromAdvisor"].Value = false;
                    cmd.Parameters["@isRemovedFromStudent"].Value = false;

                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();
        }
        
        /// <summary>
        /// Clears a specific notification for the advisor.
        /// </summary>
        /// <param name="notificationID">The ID of the notification to delete.</param>
        public void ClearNotification(int id)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string updateQuery =
                    "UPDATE notification SET isRemovedFromAdvisor = @isRemovedFromAdvisor WHERE notificationId = @notificationId;";
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@isRemovedFromAdvisor", SqlDbType.Bit);
                    cmd.Parameters["@isRemovedFromAdvisor"].Value = true;

                    cmd.Parameters.Add("@notificationId", SqlDbType.Int);
                    cmd.Parameters["@notificationId"].Value = id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Clears all notifications that have the supplied advisorID.
        /// </summary>
        /// <param name="advisorID">The advisorID to search for and delete within notifications.</param>
        public void ClearNotifications(int advisorID)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string deleteQuery = "UPDATE notification SET isRemovedFromAdvisor = @isRemovedFromAdvisor WHERE advisorID = @advisorID";


                using (var cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.Add("@isRemovedFromAdvisor", SqlDbType.Bit);
                    cmd.Parameters["@isRemovedFromAdvisor"].Value = true;
                    cmd.Parameters.Add("@advisorID", SqlDbType.Int);
                    cmd.Parameters["@advisorID"].Value = advisorID;
                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();
        }

        /// <summary>
        /// Gets a collection of notifications that have the supplied advisorID.
        /// </summary>
        /// <param name="advisorID">The advisorID with the notifications.</param>
        /// <returns>A colleciton of notifications.</returns>
        public IList<Notification> GetNotificationsByAdvisorID(int advisorID)
        {
            IList<Notification> notificationList = new List<Notification>();

            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();

                string selectString = "SELECT notificationID, advisorID, studentID, NotifMessage FROM Notification WHERE advisorID = @userID AND isRemovedFromAdvisor = @isRemovedFromAdvisor";

                using (var cmd = new SqlCommand(selectString, conn))
                {
                    cmd.Parameters.Add("@userID", System.Data.SqlDbType.Int);
                    cmd.Parameters["@userID"].Value = advisorID;
                    cmd.Parameters.Add("@isRemovedFromAdvisor", System.Data.SqlDbType.Bit);
                    cmd.Parameters["@isRemovedFromAdvisor"].Value = false;

                    using var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        
                        var studentId = reader.GetOrdinal("studentID");
                        var advisorId = reader.GetOrdinal("advisorID");
                        var message = reader.GetOrdinal("notifMessage");
                        var id = reader.GetOrdinal("notificationID");

                        while (reader.Read())
                        {
                            var notif = new Notification
                            {
                                Id = reader.GetInt32(id),
                                StudentId = reader.GetInt32(studentId),
                                AdvisorId = reader.GetInt32(advisorId),
                                NotifMessage = reader.GetString(message)
                            };

                            notificationList.Add(notif);
                        }
                    }
                    reader.Close();
                    conn.Close();
                }
            }
            return notificationList;
        }
    }
}
