using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace K180239_Q1
{
    public class Email
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public void SendMail(int port_num = 587)
        {
            MailAddress from = new MailAddress("example@gmail.com");
            MailAddress to = new MailAddress(this.To);

            MailMessage mail = new MailMessage(from, to);
            mail.Subject = this.Subject;
            mail.Body = this.Message;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = port_num;
            Console.WriteLine("Entet Your Email Address");
            string sender_email = "example@gmail.com" ;   //new string(Console.ReadLine());

            Console.WriteLine("Enter your Password");
            string email_Password = "password" ;         //new string(Console.ReadLine());

            smtp.Credentials = new NetworkCredential(
                sender_email, email_Password);
            smtp.EnableSsl = true;
            Console.WriteLine("Sending email...");
            smtp.Send(mail);
            Console.WriteLine("Eamil Sent.");

        }
    }


}
