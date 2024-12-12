using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Utils
    {
        public bool EnviarCorreo(string email, string asunto, string mensaje)
        {
            var fromAddress = new MailAddress("aspaguay@gmail.com", "Alex Paguay");
            var toAddress = new MailAddress(email, "Usuario");
            const string fromPassword = "kdnp cbct curb uqlr";

            try
            {
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var mailMessage = new MailMessage(fromAddress, toAddress)
                {
                    Subject = asunto,
                    Body = mensaje
                })
                {
                    smtp.Send(mailMessage);
                }

                return true; // Envío exitoso
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
                return false; // Envío fallido
            }
        }

    }
}
