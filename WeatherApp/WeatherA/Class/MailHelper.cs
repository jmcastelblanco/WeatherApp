using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WeatherA.Class
{
    public class MailHelper
    {
        public static bool SendMailTo(string content)
        {
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("weather.sensors.aunar@gmail.com", "Athena89401"),
                    EnableSsl = true
                };
                client.Send("weather.sensors.aunar@gmail.com", "sistemas2@ccpasto.org.co,soidneo@gmail.com", "Alerta de Broca", content);

                return true;
            }

            catch (SmtpException ex)
            {
                return false;
                //throw new ApplicationException
                //  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    
        public static bool SendMailTo2()
        {
            try
            {
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("soidneo@gmail.com", "pass")
                };
                using (var message = new MailMessage("soidneo@gmail.com", "soidneo@gmail.com,sistemas2@ccpasto.org.co")
                {
                    Subject = "Test Mail",
                    Body = "<b>Test Mail</b><br>using <b>HTML</b>."
                })
                {
                    smtp.Send(message);
                }
                return true;
            }

            catch (SmtpException ex)
            {

                return false;
                //throw new ApplicationException
                //  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}