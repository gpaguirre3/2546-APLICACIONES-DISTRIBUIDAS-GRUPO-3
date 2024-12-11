using BLL;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Security.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("LocalAPI");
        }

        // GRANULARIDAD DE PERMISOS
        [HttpPost("create")]
        [Authorize(Roles = "Administrador,Editor")]
        public async Task<CategoryDTO> CreateDTO(CategoryDTO category)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Category/CreateDTO", category);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CategoryDTO>();
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Category/Delete?id={id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        [HttpGet("filter")]
        [Authorize(Roles = "Administrador,Editor,Lector")]
        public async Task<List<CategoryDTO>> FilterDTO(string name)
        {
            var response = await _httpClient.GetAsync($"api/Category/FilterDTO?name={name}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<CategoryDTO>>();
        }

        [HttpGet("GetById/{id}")]
        [Authorize(Roles = "Administrador,Editor,Lector")]
        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var response = await _httpClient.GetAsync($"api/Category/GetCategoryById?id={id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CategoryDTO>();
        }

        [HttpPut("update")]
        [Authorize(Roles = "Administrador,Editor")]
        public async Task<bool> UpdateDTO(CategoryDTO categoryToUpdate)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Category/UpdateDTO", categoryToUpdate);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        [HttpGet("getAll")]
        [Authorize(Roles = "Administrador,Editor,Lector")]
        public async Task<List<CategoryDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync($"api/Category/GetAll");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<CategoryDTO>>();
        }
    }
}