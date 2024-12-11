using Security.Models;

namespace Security.Constants
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "jperez", Password = "admin123", Rol = "Administrador", EmailAddress = "jperez@gmail.com", FirstName = "Juan", LastName = "Perez"},
            new UserModel() { Username = "mgonzalez", Password = "admin123", Rol = "Editor", EmailAddress = "mgonzalez@gmail.com", FirstName = "Maria", LastName = "Gonzalez"},
            new UserModel() { Username = "genesis", Password = "admin123", Rol = "Lector", EmailAddress = "mgonzalez@gmail.com", FirstName = "Maria", LastName = "Gonzalez"},

        };
    }

}
