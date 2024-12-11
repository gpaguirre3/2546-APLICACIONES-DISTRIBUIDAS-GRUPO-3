using BLL;
using Entities;
using SLC;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers
{
    public class LoginAttemptsController : ApiController, ILoginAttemptsService
    {
        // Registrar un intento de inicio de sesión
        [HttpPost]
        public bool RegisterLoginAttempt(string username)
        {
            var loginAttemptsLogic = new LoginAttemptsLogic();
            var result = loginAttemptsLogic.RegisterLoginAttempt(username);
            return result;
        }

        // Verificar si una cuenta está bloqueada
        [HttpGet]
        public bool IsAccountBlocked(string username)
        {
            var loginAttemptsLogic = new LoginAttemptsLogic();
            var result = loginAttemptsLogic.IsAccountBlocked(username);
            return result;
        }

        // Desbloquear una cuenta manualmente
        [HttpPost]
        public bool UnlockAccount(string username)
        {
            var loginAttemptsLogic = new LoginAttemptsLogic();
            var result = loginAttemptsLogic.UnlockAccount(username);
            return result;
        }

        // Reiniciar los intentos de inicio de sesión de un usuario
        [HttpPost]
        public bool ResetLoginAttempts(string username)
        {
            var loginAttemptsLogic = new LoginAttemptsLogic();
            var result = loginAttemptsLogic.ResetLoginAttempts(username);
            return result;
        }

        // Obtener todos los intentos de inicio de sesión registrados
        [HttpGet]
        public List<LoginAttempts> GetAllLoginAttempts()
        {
            var loginAttemptsLogic = new LoginAttemptsLogic();
            var loginAttempts = loginAttemptsLogic.GetAllLoginAttempts();
            return loginAttempts;
        }

        // Buscar el registro de intentos de un usuario por su nombre de usuario
        [HttpGet]
        public LoginAttempts RetrieveLoginAttemptsByUsername(string username)
        {
            var loginAttemptsLogic = new LoginAttemptsLogic();
            var loginAttempts = loginAttemptsLogic.RetrieveLoginAttemptsByUsername(username);
            return loginAttempts;
        }
    }
}
