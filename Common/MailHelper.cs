using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MailHelper
    {
        public void Send(string con, string email, string sub)
        {
            var mail = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("ngothanhdanhtqt@gmail.com", "NgoThanhDanh1"),
                EnableSsl = true
            };
            var mess = new MailMessage();
            mess.To.Add(new MailAddress(email));
            mess.From = new MailAddress("ngothanhdanhtqt@gmail.com");
            mess.Body = con;
            mess.Subject = sub;

            mail.Send(mess);
        }
    }
}
