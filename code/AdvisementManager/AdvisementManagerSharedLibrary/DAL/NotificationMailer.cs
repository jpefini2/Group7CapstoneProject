using AdvisementManagerSharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibrary.DAL
{   
    public class NotificationMailer
    {
        private readonly SmtpClient client;
        private readonly string sourceEmail;

        /// <summary>
        /// Class for sending notification emails. 
        /// </summary>
        public NotificationMailer()
        {
            sourceEmail = "advisementmanager@gmail.com";
            client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(sourceEmail, "m1_xeelfish"),
                EnableSsl = true,
            };
        }

        /// <summary>
        /// Send an email notification to a specified advisor and student.
        /// </summary>
        /// <param name="advisor">The advisor to email</param>
        /// <param name="student">the student to email</param>
        /// <param name="notification">The notification</param>
        public void SendEmailNotification(Advisor advisor, Student student, Notification notification)
        {
            SendStudentEmail(student, notification);
            SendAdvisorEmail(advisor, notification);
        }

        /// <summary>
        /// Send an email to the advisor
        /// </summary>
        /// <param name="advisor">The advisor to email</param>
        /// <param name="notification">The notification</param>
        public void SendAdvisorEmail(Advisor advisor, Notification notification)
        {
            SendEmail(advisor.Email, notification.NotifMessage);
        }

        /// <summary>
        /// Send an email to the specified student.
        /// </summary>
        /// <param name="student">The student to email</param>
        /// <param name="notification">The notification</param>
        public void SendStudentEmail(Student student, Notification notification)
        {
            SendEmail(student.Email, notification.NotifMessage);
        }

        public void SendEmail(string destination, string message)
        {
            var subject = "Advisement Notification";
            client.Send(sourceEmail, destination, subject, message);
        }
    }
}
