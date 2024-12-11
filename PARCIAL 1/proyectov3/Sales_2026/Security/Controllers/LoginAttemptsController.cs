using BLL;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Security.Controllers
{
    [Route("api/LoginAttempts")]
    [ApiController]
    public class LoginAttemptsController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        // Constructor para configurar HttpClient
        public LoginAttemptsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("LocalAPI");
        }

        // Ruta POST para registrar un intento de inicio de sesión
        [HttpPost("register")]
        
        public async Task<bool> RegisterLoginAttempt([FromBody] string username)
        {
            var response = await _httpClient.PostAsJsonAsync("api/LoginAttempts/RegisterLoginAttempt", username);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        // Ruta GET para verificar si una cuenta está bloqueada
        [HttpGet("isBlocked")]
      
        public async Task<bool> IsAccountBlocked([FromQuery] string username)
        {
            var response = await _httpClient.GetAsync($"api/LoginAttempts/IsAccountBlocked?username={username}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        // Ruta POST para desbloquear una cuenta manualmente
        [HttpPost("unlock")]
       
        public async Task<bool> UnlockAccount([FromBody] string username)
        {
            var response = await _httpClient.PostAsJsonAsync("api/LoginAttempts/UnlockAccount", username);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        // Ruta POST para reiniciar los intentos de inicio de sesión de un usuario
        [HttpPost("reset")]
       
        public async Task<bool> ResetLoginAttempts([FromBody] string username)
        {
            var response = await _httpClient.PostAsJsonAsync("api/LoginAttempts/ResetLoginAttempts", username);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        // Ruta GET para obtener todos los intentos de inicio de sesión registrados
        [HttpGet("all")]
        
        public async Task<List<LoginAttempts>> GetAllLoginAttempts()
        {
            var response = await _httpClient.GetAsync("api/LoginAttempts/GetAllLoginAttempts");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<LoginAttempts>>();
        }

        // Ruta GET para buscar los intentos de inicio de sesión de un usuario por su nombre de usuario
        [HttpGet("byUsername")]
      
        public async Task<LoginAttempts> RetrieveLoginAttemptsByUsername([FromQuery] string username)
        {
            var response = await _httpClient.GetAsync($"api/LoginAttempts/RetrieveLoginAttemptsByUsername?username={username}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<LoginAttempts>();
        }
    }
}
