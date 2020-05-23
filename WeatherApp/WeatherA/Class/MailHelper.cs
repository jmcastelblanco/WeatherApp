using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherA.Class
{
    public class MailHelper
    {
        public bool SendMailTo()
        {
            try
            {

                SmtpClient mySmtpClient = new SmtpClient("smtp.server.com",25);

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new
                   System.Net.NetworkCredential("soidneo", "AAAjulieta1307");
                mySmtpClient.Credentials = basicAuthenticationInfo;

                // add from,to mailaddresses
                MailAddress from = new MailAddress("soidneo@gmail.com", "TestFromName");
                MailAddress to = new MailAddress("soidneo@gmail.com", "TestToName");
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                // add ReplyTo
                MailAddress replyTo = new MailAddress("soidneo@gmail.com");
                myMail.ReplyToList.Add(replyTo);

                // set subject and encoding
                myMail.Subject = "Test message";
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = "<b>Test Mail</b><br>using <b>HTML</b>.";
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = true;

                mySmtpClient.Send(myMail);
                return true;
            }

            catch (SmtpException ex)
            {
                throw new ApplicationException
                  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
    }
}