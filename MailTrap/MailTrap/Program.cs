using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;




namespace MailTrap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("4019c79deb5a80", "9aaab040b00430"),
                EnableSsl = true
            };
            var Mailmessage =new MailMessage("mohitsahu6992@gmail.com", "mohitsahu6992@gmail.com")
            {
                Subject = "Mail subject",
                Body = "<h1>PAIN IS INEVITABLE BUT SUFFERING IS OPTIONAL</h1>",
                IsBodyHtml = true,
            };
            client.Send(Mailmessage);
            System.Console.WriteLine("Sent");
        }
    }
}
