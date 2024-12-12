using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class UserLogic
    {
        // Método para crear un usuario
        public Users Create(Users user)
        {
            Users res = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Verificar si el usuario ya existe por nombre de usuario o correo
                Users existingUser = r.Retrieve<Users>(u => u.Username == user.Username || u.EmailAddress == user.EmailAddress);
                if (existingUser == null)
                {
                    res = r.Create(user);
                }
                else
                {
                    throw new Exception("El usuario ya existe con el mismo nombre de usuario o correo electrónico.");
                }
            }
            return res;
        }

        // Método para crear un usuario utilizando DTO
        public UserDTO CreateDTO(UserDTO userDTO)
        {
            UserDTO res = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Mapear UserDTO a entidad Users
                var userEntity = new Users
                {
                    Username = userDTO.Username,
                    EmailAddress = userDTO.EmailAddress,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Rol = userDTO.Rol
                };

                // Verificar si ya existe un usuario con el mismo nombre o correo
                Users existingUser = r.Retrieve<Users>(u => u.Username == userEntity.Username || u.EmailAddress == userEntity.EmailAddress);
                if (existingUser == null)
                {
                    Users createdUser = r.Create(userEntity);

                    // Mapear la entidad creada a UserDTO
                    res = new UserDTO
                    {
                        UserId = createdUser.UserId,
                        Username = createdUser.Username,
                        EmailAddress = createdUser.EmailAddress,
                        FirstName = createdUser.FirstName,
                        LastName = createdUser.LastName,
                        Rol = createdUser.Rol
                    };
                }
                else
                {
                    throw new Exception("El usuario ya existe con el mismo nombre de usuario o correo electrónico.");
                }
            }
            return res;
        }

        // Método para buscar un usuario por ID
        public Users RetrieveById(int id)
        {
            Users res = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                res = r.Retrieve<Users>(u => u.UserId == id);
            }
            return res;
        }

        // Método para buscar un usuario por ID utilizando DTO
        public UserDTO GetUserById(int id)
        {
            UserDTO res = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                var user = r.Retrieve<Users>(u => u.UserId == id);
                if (user != null)
                {
                    res = new UserDTO
                    {
                        UserId = user.UserId,
                        Username = user.Username,
                        EmailAddress = user.EmailAddress,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Rol = user.Rol
                    };
                }
            }
            return res;
        }

        // Método para actualizar un usuario
        public bool Update(Users userToUpdate)
        {
            bool res = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Users existingUser = r.Retrieve<Users>(u => u.Username == userToUpdate.Username && u.UserId != userToUpdate.UserId);
                if (existingUser == null)
                {
                    res = r.Update(userToUpdate);
                }
                else
                {
                    throw new Exception("Ya existe otro usuario con el mismo nombre de usuario.");
                }
            }
            return res;
        }

        // Método para actualizar un usuario utilizando DTO
        public bool UpdateDTO(UserDTO userDTO)
        {
            bool res = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                var userEntity = new Users
                {
                    UserId = userDTO.UserId,
                    Username = userDTO.Username,
                    EmailAddress = userDTO.EmailAddress,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Rol = userDTO.Rol
                };

                Users existingUser = r.Retrieve<Users>(u => u.Username == userEntity.Username && u.UserId != userEntity.UserId);
                if (existingUser == null)
                {
                    res = r.Update(userEntity);
                }
                else
                {
                    throw new Exception("Ya existe otro usuario con el mismo nombre de usuario.");
                }
            }
            return res;
        }

        // Método para eliminar un usuario
        public bool Delete(int id)
        {
            bool res = false;
            var user = RetrieveById(id);
            if (user != null)
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    res = r.Delete(user);
                }
            }
            else
            {
                throw new Exception("El usuario no existe.");
            }
            return res;
        }

        // Método para filtrar usuarios por nombre de usuario
        public List<Users> Filter(string username)
        {
            List<Users> res = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                res = r.Filter<Users>(u => u.Username.Contains(username));
            }
            return res;
        }

        // Método para filtrar usuarios utilizando DTO
        public List<UserDTO> FilterUsersDTO(string username)
        {
            List<UserDTO> res = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                var users = r.Filter<Users>(u => u.Username.Contains(username));
                res = users.Select(u => new UserDTO
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    EmailAddress = u.EmailAddress,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Rol = u.Rol
                }).ToList();
            }
            return res;
        }
        //verificar si un username existe
        // Método para verificar si un nombre de usuario existe en la base de datos
        public bool UsernameExists(string username)
        {
            bool exists = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Verificar si existe un usuario con el nombre de usuario especificado
                exists = r.Retrieve<Users>(u => u.Username == username) != null;
            }
            return exists;
        }
        public bool UsernameOrEmailExists(string username, string email)
        {
            bool exists = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Verificar si existe un usuario con el nombre de usuario o el correo electrónico especificado
                exists = r.Retrieve<Users>(u => u.Username == username || u.EmailAddress == email) != null;
            }
            return exists;
        }

        //autenticar
        // Método para autenticar un usuario (por nombre de usuario o correo electrónico) y devolver un UserDTO
        public UserDTO Authenticate(string username, string password)
        {
            UserDTO res = null;

            using (var r = RepositoryFactory.CreateRepository())
            {
                // Buscar al usuario por nombre de usuario o correo electrónico
                Users user = r.Retrieve<Users>(u => u.Username == username.ToLower() || u.EmailAddress == username.ToLower());

                if (user != null)
                {
                    // Verificar la contraseña usando BCrypt
                    if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                    {
                        // Mapear la entidad de usuario a un DTO si la autenticación es exitosa
                        res = new UserDTO
                        {
                            UserId = user.UserId,
                            Username = user.Username,
                            EmailAddress = user.EmailAddress,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Rol = user.Rol
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return res; // Devuelve null si no hay coincidencias o si la contraseña no es correcta
        }
        // Método para obtener el correo de un usuario basado en su nombre de usuario
        public string GetEmail(string username)
        {
            string email = null;

            using (var r = RepositoryFactory.CreateRepository())
            {
                // Recuperar el usuario por su nombre de usuario (o correo electrónico)
                Users user = r.Retrieve<Users>(u => u.Username == username.ToLower());

                // Si el usuario existe, devolver su correo electrónico
                if (user != null)
                {
                    email = user.EmailAddress;
                }
            }

            return email;  // Retorna el correo o null si no existe el usuario
        }

    }
}
