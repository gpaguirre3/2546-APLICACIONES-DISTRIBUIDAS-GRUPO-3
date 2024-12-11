using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using BCrypt.Net;
using DAL;
using Entities;
using BLL;

namespace Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        // Método de login
        [HttpPost("login")]
        public IActionResult Login(LoginUser userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                // Crear el token
                var token = Generate(user);
                return Ok(token);
            }

            return NotFound("Usuario no encontrado");
        }

        // Método de autenticación
        private UserModel Authenticate(LoginUser userLogin)
        {
            UserLogic userLogic= new UserLogic();
            UserDTO userDTO = userLogic.Authenticate(userLogin.UserName, userLogin.Password);
            UserModel userModel = new UserModel();
            if(userDTO != null)
            {
                userModel.Username = userDTO.Username;
                userModel.EmailAddress = userDTO.EmailAddress;
                userModel.Rol=userDTO.Rol;
                userModel.FirstName = userDTO.FirstName;
                userModel.LastName = userDTO.LastName;
                userModel.Password = userLogin.Password;
                return userModel;
            }
            else
            {
                return null;
            }
            
        }

        
        // Método para generar JWT
        private string Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Rol),
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Método de registro
        [HttpPost("register")]
        public bool Register(string username, string password, string rol, string emailAddress, string firstName, string lastName)
        {
            // Verificar si el usuario ya existe
            Users users = new Users();
            var UserLogic = new UserLogic();
            if (UserLogic.UsernameExists(username))
            {
                return false;  // El usuario ya existe
            }
            //HASHING DE CONTRASEÑAS SEGURAS
            // Cifrar la contraseña antes de almacenarla
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            users.UserId = 1;
            users.Username = username;
            users.Password = hashedPassword;
            users.EmailAddress = emailAddress;
            users.FirstName = firstName;
            users.LastName = lastName;
            users.Rol = rol;
            // Insertar el nuevo usuario en la base de datos
           
            var user = UserLogic.Create(users);
            return true;
        }
        
        // Método para obtener el correo electrónico del usuario
        [HttpGet("obtenerCorreo")]
        public IActionResult ObtenerCorreo(string username)
        {
            UserLogic userLogic= new UserLogic();
            var email = userLogic.GetEmail(username);

            if (email != null)
            {
                return Ok(email);
            }

            return NotFound("Usuario no encontrado");
        }
        // Método para verificar si el nombre de usuario ya existe
        [HttpPost("verificarUsuario")]
        public IActionResult VerificarUsuario(string username)
        {
            UserLogic userLogic = new UserLogic();

            bool usernameExists = userLogic.UsernameExists(username);

            if (usernameExists)
            {
                return Conflict("El nombre de usuario ya existe.");
            }
            else
            {
                return Ok("El nombre de usuario está disponible.");
            }
        }




    }
}
