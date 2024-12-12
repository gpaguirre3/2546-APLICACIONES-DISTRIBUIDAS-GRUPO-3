using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BLL
{
    public class LoginAttemptsLogic
    {
        // Método para registrar un intento de inicio de sesión
        public bool RegisterLoginAttempt(string username)
        {
            bool isBlocked = false;
            using (var repository = RepositoryFactory.CreateRepository())
            {
                // Buscar si el usuario ya tiene un registro en la tabla LoginAttempts
                var loginAttempt = repository.Retrieve<LoginAttempts>(l => l.Username == username);

                if (loginAttempt == null)
                {
                    // Crear un nuevo registro si no existe
                    loginAttempt = new LoginAttempts
                    {
                        Username = username,
                        AttemptCount = 1,
                        LastAttempt = DateTime.Now,
                        IsBlocked = false,
                        BlockUntil = null
                    };
                    repository.Create(loginAttempt);
                }
                else
                {
                    // Incrementar el contador de intentos
                    loginAttempt.AttemptCount++;
                    loginAttempt.LastAttempt = DateTime.Now;

                    // Bloquear al usuario si supera el número de intentos permitidos
                    if (loginAttempt.AttemptCount >= 3)
                    {
                        loginAttempt.IsBlocked = true;
                        loginAttempt.BlockUntil = DateTime.Now.AddMinutes(2); // Bloqueo por 15 minutos
                    }

                    repository.Update(loginAttempt);
                }

                isBlocked = loginAttempt.IsBlocked;
            }
            return isBlocked;
        }

        // Método para verificar si un usuario está bloqueado
        public bool IsAccountBlocked(string username)
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                var loginAttempt = repository.Retrieve<LoginAttempts>(l => l.Username == username);

                if (loginAttempt != null)
                {
                    // Si está bloqueado, verificar si ya expiró el tiempo de bloqueo
                    if (loginAttempt.IsBlocked && loginAttempt.BlockUntil.HasValue && loginAttempt.BlockUntil <= DateTime.Now)
                    {
                        // Desbloquear al usuario
                        loginAttempt.IsBlocked = false;
                        loginAttempt.AttemptCount = 0;
                        loginAttempt.BlockUntil = null;
                        repository.Update(loginAttempt);
                        return false;
                    }

                    return loginAttempt.IsBlocked;
                }
            }
            return false; // Si no hay registro, no está bloqueado
        }

        // Método para desbloquear manualmente una cuenta
        public bool UnlockAccount(string username)
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                var loginAttempt = repository.Retrieve<LoginAttempts>(l => l.Username == username);

                if (loginAttempt != null)
                {
                    loginAttempt.IsBlocked = false;
                    loginAttempt.AttemptCount = 0;
                    loginAttempt.BlockUntil = null;

                    return repository.Update(loginAttempt);
                }
            }
            return false; // Si no existe el usuario, no se pudo desbloquear
        }

        // Método para reiniciar los intentos de un usuario
        public bool ResetLoginAttempts(string username)
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                var loginAttempt = repository.Retrieve<LoginAttempts>(l => l.Username == username);

                if (loginAttempt != null)
                {
                    loginAttempt.AttemptCount = 0;
                    loginAttempt.LastAttempt = DateTime.Now;

                    return repository.Update(loginAttempt);
                }
            }
            return false; // Si no existe el usuario, no se pudieron reiniciar los intentos
        }

        // Método para obtener todos los intentos de inicio de sesión
        public List<LoginAttempts> GetAllLoginAttempts()
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                return repository.GetAll<LoginAttempts>();
            }
        }
        //
        // Método para buscar el registro de intentos de inicio de sesión por nombre de usuario
        public LoginAttempts RetrieveLoginAttemptsByUsername(string username)
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                // Recupera el registro de LoginAttempts basado en el nombre de usuario
                var loginAttempt = repository.Retrieve<LoginAttempts>(l => l.Username == username);
                return loginAttempt;
            }
        }
        //
        public bool UserExists(string username)
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                var loginAttempt = repository.Retrieve<LoginAttempts>(l => l.Username == username);
                return loginAttempt != null; // Retorna verdadero si existe el registro
            }
        }

        // Método para crear un registro de usuario
        public void CreateUserRecord(string username)
        {
            using (var repository = RepositoryFactory.CreateRepository())
            {
                var loginAttempt = new LoginAttempts
                {
                    Username = username,
                    AttemptCount = 0, // Inicializa el contador de intentos en 0
                    LastAttempt = DateTime.Now,
                    IsBlocked = false,
                    BlockUntil = null
                };

                repository.Create(loginAttempt); // Usa el método Create del repositorio
            }
        }


    }
}
