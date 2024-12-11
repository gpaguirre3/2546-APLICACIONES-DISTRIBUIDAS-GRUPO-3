using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RegistroLogic
    {
        // Generar código de verificación
        public string GenerateVerificationCode(int length = 6)
        {
            const string chars = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // Enviar código de verificación por correo
        public bool EnviarCodigoVerificacion(string email, string codigo)
        {
            try
            {
                var fromAddress = new MailAddress("aspaguay@gmail.com", "Alex Paguay");
                var toAddress = new MailAddress(email, "Usuario");
                const string fromPassword = "kdnp cbct curb uqlr";
                const string subject = "Código de Verificación";
                string body = $"Tu código de verificación es: {codigo}";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
                return false;
            }
        }

    }
}
