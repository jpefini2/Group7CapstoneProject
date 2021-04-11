using AdvisementManagerSharedLibrary.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerDesktopApp.DAL
{
    class NotificationDal
    {
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
