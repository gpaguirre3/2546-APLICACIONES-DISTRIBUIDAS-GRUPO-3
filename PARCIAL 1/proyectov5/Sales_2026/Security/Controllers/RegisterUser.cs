namespace Security.Controllers
{
    public class RegisterUser
    {
        public string Username { get; set; }   // Nombre de usuario
        public string Password { get; set; }   // Contraseña (debería ser hasheada antes de almacenarse)
        public string Rol { get; set; }        // Rol del usuario (por ejemplo, "Admin", "User", etc.)
        public string EmailAddress { get; set; }  // Dirección de correo electrónico del usuario
        public string FirstName { get; set; }  // Nombre del usuario
        public string LastName { get; set; }   // Apellido del usuario
    }
}
