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
        public void SendEmailNotification(Advisor advisor, Student student, Notification notification)
        {
            SendStudentEmail(student, notification);
            SendAdvisorEmail(advisor, notification);
        }

        public void SendAdvisorEmail(Advisor advisor, Notification notification)
        {
            SendEmail(advisor.Email, notification.NotifMessage);
        }

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
