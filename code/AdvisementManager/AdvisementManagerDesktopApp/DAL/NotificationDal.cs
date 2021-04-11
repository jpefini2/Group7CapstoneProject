using AdvisementManagerSharedLibrary.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerDesktopApp.DAL
{
    class NotificationDal
    {
        public void AddNotification(int studentID, int advisorID, string message)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string updateQuery =
                    "INSERT INTO Notification (studentID, advisorID, notifMessage) VALUES (@studentID, @advisorID, @notifMessage);";

                using (var cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.Add("@advisorID", SqlDbType.Int);
                    cmd.Parameters.Add("@studentID", SqlDbType.Int);
                    cmd.Parameters.Add("@notifMessage", SqlDbType.VarChar);

                    cmd.Parameters["@studentID"].Value = studentID;
                    cmd.Parameters["@advisorID"].Value = advisorID;
                    cmd.Parameters["@notifMessage"].Value = message;

                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();
        }

        public void DeleteNotification(int notificationID)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string deleteQuery = "DELETE FROM Notification WHERE notificationID = @notificationID";


                using (var cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.Add("@notificationID", SqlDbType.Int);
                    cmd.Parameters["@notificationID"].Value = notificationID;
                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();
        }

        public void ClearNotifications(int advisorID)
        {
            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                const string deleteQuery = "DELETE FROM Notification WHERE advisorID = @advisorID";


                using (var cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.Add("@advisorID", SqlDbType.Int);
                    cmd.Parameters["@advisorID"].Value = advisorID;
                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();
        }

        public IList<Notification> GetNotificationsByAdvisorID(int userId)
        {
            IList<Notification> notificationList = new List<Notification>();

            var conn = DbConnection.GetConnection();
            using (conn)
            {
                conn.Open();

                string selectString = "SELECT notificationID, advisorID, studentID, NotifMessage FROM Notification WHERE advisorID = @userID";

                using (var cmd = new SqlCommand(selectString, conn))
                {
                    cmd.Parameters.Add("@userID", System.Data.SqlDbType.Int);
                    cmd.Parameters["@userID"].Value = userId;

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
