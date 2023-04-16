using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Admins.Foundations.Mapper.Helper
{
    public static class MailHelper
    {
        public static void SendActivation(string code, string email)
        {
            string body = string.Format(@"Hi @email,
                         <br><br>
                         A Request Has Been Recieved To Change The Password For Your Administrator Account.
                         <br><br>
                         Use Your Secret Code!
                         <strong>@code</strong>
                         <br><br>
                         This Secret Code <strong>@code</strong> Has Been Expired Within 15 Minutes.
                         <br><br>
                         Unfortunately, responses to this email won't be read.
                ");

            body = body.Replace("@code", code);
            body = body.Replace("@email", email);
            SendMail(email, "Reset Administrator Password!", body);
        }

        public static bool SendMail(string ToEmail, string subject, string Body)
        {
            try
            {
                MailMessage MyMessage = new MailMessage();
                MyMessage.To.Add(ToEmail);

                MyMessage.Subject = subject;
                MyMessage.Body = Body;
                MyMessage.IsBodyHtml = true;

                MyMessage.From = new MailAddress(ToEmail, "For Demo Purpose");


                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new NetworkCredential("demo@gmail.com", "Marbles#123");
                smtp.EnableSsl = true;

                smtp.Send(MyMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
