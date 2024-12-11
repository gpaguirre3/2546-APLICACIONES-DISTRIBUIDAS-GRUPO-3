using Entities;
using System;
using System.Collections.Generic;

namespace SLC
{
    public interface ILoginAttemptsService
    {
        // Registrar un intento de inicio de sesión
        bool RegisterLoginAttempt(string username);

        // Verificar si una cuenta está bloqueada
        bool IsAccountBlocked(string username);

        // Desbloquear una cuenta manualmente
        bool UnlockAccount(string username);

        // Reiniciar los intentos de inicio de sesión de un usuario
        bool ResetLoginAttempts(string username);

        // Obtener todos los intentos de inicio de sesión registrados
        List<LoginAttempts> GetAllLoginAttempts();

        // Buscar el registro de intentos de un usuario por su nombre de usuario
        LoginAttempts RetrieveLoginAttemptsByUsername(string username);
    }
}
