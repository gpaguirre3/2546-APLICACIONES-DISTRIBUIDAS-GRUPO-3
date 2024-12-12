using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    //[Serializable]
    public class UserDTO
    {
        public int UserId { get; set; } // Identificador del usuario
        public string Username { get; set; } // Nombre de usuario
        public string EmailAddress { get; set; } // Dirección de correo electrónico
        public string FirstName { get; set; } // Nombre
        public string LastName { get; set; } // Apellido
        public string Rol { get; set; } // Rol del usuario
    }
}
