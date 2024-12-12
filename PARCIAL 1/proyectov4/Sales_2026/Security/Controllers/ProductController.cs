using BLL;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Security.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        // Constructor para configurar HttpClient
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("LocalAPI");
        }

        // Ruta POST para crear un producto
        // GRANULARIDAD DE PERMISOS
        [HttpPost("create")]
        [Authorize(Roles = "Administrador,Editor")]
        public async Task<ProductDTO> CreateProductDTO([FromBody] ProductDTO product)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Product/CreateProductDTO", product);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProductDTO>();
        }

        // Ruta DELETE para eliminar un producto por ID
        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Product/Delete?id={id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        // Ruta GET para filtrar productos por nombre
        [HttpGet("filter")]
        [Authorize(Roles = "Administrador,Editor,Lector")]
        public async Task<List<ProductDTO>> FilterProducts([FromQuery] string name)
        {
            var response = await _httpClient.GetAsync($"api/Product/FilterProducts?name={name}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ProductDTO>>();
        }

        // Ruta GET para obtener un producto por ID
        [HttpGet("GetById/{id}")]
        [Authorize(Roles = "Administrador,Editor,Lector")]
        public async Task<ProductDTO> GetProductById(int id)
        {
            var response = await _httpClient.GetAsync($"api/Product/GetProductById/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProductDTO>();
        }

        // Ruta PUT para actualizar un producto con DTO
        [HttpPut("update")]
        [Authorize(Roles = "Administrador,Editor")]
        public async Task<bool> UpdateProductDTO([FromBody] ProductDTO productToUpdate)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Product/UpdateProductDTO", productToUpdate);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        // Ruta GET para obtener un producto por ID
        [HttpGet("FilterByCategory/{id}")]
        [Authorize(Roles = "Administrador,Editor,Lector")]
        public async Task<List<ProductDTO>> FilterProductsDTOByCategoryID(int id)
        {
            var response = await _httpClient.GetAsync($"api/Product/FilterProductsDTOByCategoryID?id={id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ProductDTO>>();
        }
    }
}
