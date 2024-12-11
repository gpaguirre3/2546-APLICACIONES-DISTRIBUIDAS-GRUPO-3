using System;
using System.Net.Mail;
using System.Web.Mvc;
using System.Linq;
using System.Net;
using NWindProxyService1;
using System.Threading.Tasks;
using BLL;

namespace NWind.MVCPLS.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult Registro()
        {
            return View();
        }

        // Método para generar código de verificación
        private string GenerateVerificationCode(int length = 6)
        {
            const string chars = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // Método para enviar correo de verificación
        private bool EnviarCodigoVerificacion(string email, string codigo)
        {
            try
            {
                //var fromAddress = new MailAddress("genesiscalapaquip@gmail.com", "Genesis");
                var fromAddress = new MailAddress("aspaguay@gmail.com", "Alex Paguay");
                var toAddress = new MailAddress(email, "Usuario");
                //const string fromPassword = "ffdj imuw fiif enlm";
                //kdnp cbct curb uqlr
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
                // Log error (puedes utilizar un sistema de logs como NLog, Serilog, etc.)
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
                return false;
            }
        }

        // Acción para generar y enviar el código de verificación
        [HttpPost]
        public JsonResult GenerarCodigoVerificacion(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return Json(new { success = false, error = "El correo electrónico es obligatorio." });
            }

            string codigo = GenerateVerificationCode();
            bool enviado = EnviarCodigoVerificacion(email, codigo);

            if (enviado)
            {
                // Guardar código en sesión para validación posterior
                Session["VerificationCode"] = codigo;
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, error = "No se pudo enviar el código de verificación." });
            }
        }

        // Acción para verificar el código ingresado
        [HttpPost]
        public JsonResult VerificarCodigo(string codigo)
        {
            if (Session["VerificationCode"] != null && Session["VerificationCode"].ToString() == codigo)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "El código de verificación es incorrecto." });
        }

        // Acción para registrar al usuario
        [HttpPost]
        public ActionResult Registro(string usuario, string firstName, string lastName, string email, string password, string role)
        {
            try
            {


                var proxy = new Proxy();
                string resultMessage = proxy.Register(usuario, password, role, email, firstName, lastName);

                if (resultMessage == "Registro exitoso")
                {
                    // Limpiar sesión
                    HttpContext.Session.Remove("CodigoVerificacion");
                    HttpContext.Session.Remove("EmailRegistro");

                    return Json(new { success = true, message = resultMessage });
                }
                else
                {
                    // Devolver mensaje de error al cliente
                    return Json(new { success = false, message = resultMessage });
                }
            }
            catch (Exception ex)
            {
                // Devolver mensaje de error en caso de excepción
                return Json(new { success = false, message = $"Ocurrió un error en el servidor: {ex.Message}" });
            }
        }
        // Acción para verificar si el nombre de usuario ya existe
        [HttpPost]
        public async Task<JsonResult> VerificarUsuario(string usuario)
        {
            // Se crea una instancia de UserLogic para realizar la verificación
            UserLogic userLogic = new UserLogic();

            // Validación de entrada: Si el usuario está vacío o nulo, retorna un mensaje de error
            if (string.IsNullOrEmpty(usuario))
            {
                return Json(new { success = false, error = "El nombre de usuario es obligatorio." });
            }

            try
            {
                // Llamamos directamente a UsernameExists sin await si no es un método asíncrono
                bool usuarioExistente = userLogic.UsernameExists(usuario);  // Sin 'await'

                // Si el usuario ya existe, devolvemos un mensaje de error
                if (usuarioExistente)
                {
                    return Json(new { success = false, message = "El nombre de usuario ya está registrado." });
                }

                // Si el usuario no existe, devolvemos un mensaje de éxito
                return Json(new { success = true, message = "El nombre de usuario está disponible." });
            }
            catch (Exception ex)
            {
                // En caso de error, devolvemos el mensaje de error
                return Json(new { success = false, message = $"Ocurrió un error al verificar el usuario: {ex.Message}" });
            }
        }
        // Acción para verificar si el nombre de usuario o correo electrónico ya existe
        [HttpPost]
        public async Task<JsonResult> VerificarUsuarioOEmail(string usuario, string email)
        {
            // Se crea una instancia de UserLogic para realizar la verificación
            UserLogic userLogic = new UserLogic();

            // Validación de entrada: Si ambos parámetros están vacíos o nulos, retorna un mensaje de error
            if (string.IsNullOrEmpty(usuario) && string.IsNullOrEmpty(email))
            {
                return Json(new { success = false, error = "El nombre de usuario o el correo electrónico es obligatorio." });
            }

            try
            {
                // Llamamos al nuevo método UsernameOrEmailExists para verificar si el usuario o el correo ya existen
                bool usuarioOEmailExistente = userLogic.UsernameOrEmailExists(usuario, email);  // Verificar usuario o correo

                // Si el usuario o correo electrónico ya existe, devolvemos un mensaje de error
                if (usuarioOEmailExistente)
                {
                    return Json(new { success = false, message = "El nombre de usuario o correo electrónico ya está registrado." });
                }

                // Si el usuario y correo no existen, devolvemos un mensaje de éxito
                return Json(new { success = true, message = "El nombre de usuario o correo electrónico está disponible." });
            }
            catch (Exception ex)
            {
                // En caso de error, devolvemos el mensaje de error
                return Json(new { success = false, message = $"Ocurrió un error al verificar el usuario o correo electrónico: {ex.Message}" });
            }
        }





    }

    // Modelo de registro para ejemplo
    public class RegistroModel
    {
        public string Usuario { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}