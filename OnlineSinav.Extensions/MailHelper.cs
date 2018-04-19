using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.Extensions
{
    public class MailHelper
    {
        public static bool SendMail(string mail, Guid activationCode)
        {
            try
            {
                MailAddress fromAddress = new MailAddress("nbuy404@outlook.com");
                MailAddress toAddress = new MailAddress(mail);

                string subject = "Üyelik Aktivasyon";
                string mailBody = string.Format("<a href='http://localhost:11608/Account/ActivateUser?activationCode={0}'>Aktivasyon için tıklayınız</a>", activationCode);

                MailMessage mailMessage = new MailMessage();
                mailMessage.Subject = subject;
                mailMessage.Body = mailBody;
                mailMessage.IsBodyHtml = true;
                mailMessage.From = fromAddress;
                mailMessage.To.Add(toAddress);

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(fromAddress.Address, "N4b0u4y1");
                smtp.EnableSsl = true;

                smtp.Send(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
