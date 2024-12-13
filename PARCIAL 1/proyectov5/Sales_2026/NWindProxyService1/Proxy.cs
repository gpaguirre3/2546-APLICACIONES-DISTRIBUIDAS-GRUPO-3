using Entities;
using SLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BLL;

namespace NWindProxyService1
{
    public class Proxy : IProductService, ICategoryService


    {
        string BaseAddress = "https://localhost:7292";

        public async Task<T> SendPost<T, PostData>(string requestURI, PostData data, string bearerToken)
        {
            T result = default(T);
            using (var client = new HttpClient())
            {
                try
                {
                    // Construir URL absoluto
                    requestURI = BaseAddress + requestURI;

                    // Configurar encabezados de la solicitud
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(bearerToken))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                    }

                    // Serializar el cuerpo de la solicitud
                    var jsonData = JsonConvert.SerializeObject(data);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Enviar la solicitud POST
                    HttpResponseMessage response = await client.PostAsync(requestURI, content);

                    // Leer y deserializar la respuesta
                    var resultWebAPI = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T>(resultWebAPI);
                }
                catch (Exception ex)
                {
                    // Manejar la excepción según sea necesario
                }
            }
            return result;
        }


        public async Task<T> SendPut<T, PutData>(string requestURI, PutData data, string bearerToken)
        {
            T result = default(T);
            using (var client = new HttpClient())
            {
                try
                {
                    // Construir URL absoluto
                    requestURI = BaseAddress + requestURI;

                    // Configurar encabezados de la solicitud
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(bearerToken))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                    }

                    // Serializar el cuerpo de la solicitud
                    var jsonData = JsonConvert.SerializeObject(data);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Enviar la solicitud PUT
                    HttpResponseMessage response = await client.PutAsync(requestURI, content);

                    // Leer y deserializar la respuesta
                    var resultWebAPI = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T>(resultWebAPI);
                }
                catch (Exception ex)
                {
                    // Manejar la excepción según sea necesario
                }
            }
            return result;
        }
        public async Task<bool> SendDelete(string requestURI, string bearerToken)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // Construir URL absoluto
                    requestURI = BaseAddress + requestURI;

                    // Configurar encabezados de la solicitud
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(bearerToken))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                    }

                    // Enviar la solicitud DELETE
                    HttpResponseMessage response = await client.DeleteAsync(requestURI);

                    // Retornar true si la solicitud fue exitosa
                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    // Manejar la excepción según sea necesario
                }
            }
            return false; // Retornar false en caso de error
        }


        public async Task<T> SendGet<T>(string requestURI, string bearerToken)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    requestURI = BaseAddress + requestURI; // URL Absoluto 

                    // Agregar el encabezado Authorization con el Bearer token
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(bearerToken))
                    {
                        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                    }

                    var ResultJSON = await Client.GetStringAsync(requestURI);
                    Result = JsonConvert.DeserializeObject<T>(ResultJSON);
                }
                catch (Exception ex)
                {
                    // Manejar la excepción  
                }
            }
            return Result;
        }


        public Categories Create(Categories category)
        {
            throw new NotImplementedException();
        }

        public Products CreateProduct(Products products)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Categories> Filter(string name)
        {
            throw new NotImplementedException();
        }

     


        public Categories RetrieveById(int id)
        {
            throw new NotImplementedException();
        }

        public Products RetrieveProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Categories categoryToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Products productToUpdate)
        {
            throw new NotImplementedException();
        }

        List<Products> IProductService.Filter(string name)
        {
            throw new NotImplementedException();
        }

        public List<ProductDTO> FilterProductsDTOByCategoryID(int ID, string bearerToken)
        {
            List<ProductDTO> Result = null;
            Task.Run(async () => Result = await
            FilterProductsDTOByCategoryIDAsync(ID, bearerToken)).Wait();

            return Result;
        }

        public async Task<List<ProductDTO>> FilterProductsDTOByCategoryIDAsync(int ID, string bearerToken)
        {
            return await SendGet<List<ProductDTO>>(
                $"/api/Product/FilterByCategory/{ID}", bearerToken);
        }

        // Crear producto
        public async Task<ProductDTO> CreateProductDTOAsync(ProductDTO newProduct, string bearerToken)
        {
            return await SendPost<ProductDTO, ProductDTO>("/api/Product/create", newProduct, bearerToken);
        }

        public ProductDTO CreateProductDTO(ProductDTO newProduct, string bearerToken)
        {
            ProductDTO result = null;
            Task.Run(async () => result = await CreateProductDTOAsync(newProduct, bearerToken)).Wait();
            return result;
        }

        // Obtener producto por ID
        public async Task<ProductDTO> RetrieveProductDTOByIDAsync(int ID, string bearerToken)
        {
            return await SendGet<ProductDTO>($"/api/Product/GetById/{ID}", bearerToken);
        }

        public ProductDTO RetrieveProductByID(int ID, string bearerToken)
        {
            ProductDTO result = null;
            Task.Run(async () => result = await RetrieveProductDTOByIDAsync(ID, bearerToken)).Wait();
            return result;
        }

        // Actualizar producto
        public async Task<bool> UpdateProductDTOAsync(ProductDTO productToUpdate, string bearerToken)
        {
            return await SendPut<bool, ProductDTO>("/api/Product/update", productToUpdate, bearerToken);
        }

        public bool UpdateProductDTO(ProductDTO productToUpdate, string bearerToken)
        {
            bool result = false;
            Task.Run(async () => result = await UpdateProductDTOAsync(productToUpdate, bearerToken)).Wait();
            return result;
        }

        // Borrar producto
        public async Task<bool> DeleteProductAsync(int ID, string bearerToken)
        {
            return await SendDelete($"/api/Product/delete/{ID}", bearerToken);
        }

        public bool DeleteProduct(int ID, string bearerToken)
        {
            bool result = false;
            Task.Run(async () => result = await DeleteProductAsync(ID, bearerToken)).Wait();
            return result;
        }

        // Filtrar productos por nombre
        public List<ProductDTO> FilterProductsDTOByName(string name, string bearerToken)
        {
            List<ProductDTO> result = null;
            Task.Run(async () => result = await FilterProductsDTOByNameAsync(name, bearerToken)).Wait();
            return result;
        }

        public async Task<List<ProductDTO>> FilterProductsDTOByNameAsync(string name, string bearerToken)
        {
            // Construir la URL con el parámetro de consulta
            string requestURI = $"/api/Product/filter?name={Uri.EscapeDataString(name)}";
            return await SendGet<List<ProductDTO>>(requestURI, bearerToken);
        }


        // Crear categoría
        public async Task<CategoryDTO> CreateCategoryDTOAsync(CategoryDTO newCategory, string bearerToken)
        {
            return await SendPost<CategoryDTO, CategoryDTO>("/api/Category/create", newCategory, bearerToken);
        }

        public CategoryDTO CreateCategoryDTO(CategoryDTO newCategory, string bearerToken)
        {
            try
            {
                CategoryDTO result = null;

                // Ejecutar la tarea asincrónica para obtener el resultado
                Task.Run(async () => result = await CreateCategoryDTOAsync(newCategory, bearerToken)).Wait();

                // Verificar si el resultado es nulo y devolver un error explícito en ese caso
                if (result == null)
                {
                    return new CategoryDTO
                    {
                        CategoryName = "Error",
                        Description = "El servidor no devolvió un resultado válido."
                    };
                }

                return result;
            }
            catch (Exception ex)
            {
                // Log del error en la consola para depuración
                Console.WriteLine($"Error al crear categoría: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }

                // Devolver el error como un objeto CategoryDTO
                return new CategoryDTO
                {
                    CategoryName = "Error",
                    Description = $"Excepción: {ex.Message}"
                };
            }
        }




        // Filtrar categorías por nombre
        public List<CategoryDTO> FilterCategoriesByName(string name, string bearerToken)
        {
            List<CategoryDTO> result = null;
            Task.Run(async () => result = await FilterCategoriesByNameAsync(name, bearerToken)).Wait();
            return result;
        }

        public async Task<List<CategoryDTO>> FilterCategoriesByNameAsync(string name, string bearerToken)
        {
            string requestURI = $"/api/Category/filter?name={Uri.EscapeDataString(name)}";
            return await SendGet<List<CategoryDTO>>(requestURI, bearerToken);
        }

        // Obtener categoría por ID
        public CategoryDTO GetCategoryById(int id, string bearerToken)
        {
            CategoryDTO result = null;
            Task.Run(async () => result = await GetCategoryByIdAsync(id, bearerToken)).Wait();
            return result;
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id, string bearerToken)
        {
            string requestURI = $"/api/Category/GetById/{id}";
            return await SendGet<CategoryDTO>(requestURI, bearerToken);
        }

        // Actualizar categoría
        public bool UpdateCategory(CategoryDTO categoryToUpdate, string bearerToken)
        {
            bool result = false;
            Task.Run(async () => result = await UpdateCategoryAsync(categoryToUpdate, bearerToken)).Wait();
            return result;
        }

        public async Task<bool> UpdateCategoryAsync(CategoryDTO categoryToUpdate, string bearerToken)
        {
            return await SendPut<bool, CategoryDTO>("/api/Category/update", categoryToUpdate, bearerToken);
        }

        // Eliminar categoría
        public bool DeleteCategory(int id, string bearerToken)
        {
            bool result = false;
            Task.Run(async () => result = await DeleteCategoryAsync(id, bearerToken)).Wait();
            return result;
        }

        public async Task<bool> DeleteCategoryAsync(int id, string bearerToken)
        {
            string requestURI = $"/api/Category/delete/{id}";
            return await SendDelete(requestURI, bearerToken);
        }

        // Filtrar categorías por nombre
        public List<CategoryDTO> GetAllCategories(string bearerToken)
        {
            List<CategoryDTO> result = null;
            Task.Run(async () => result = await GetAllCategoriesAsync(bearerToken)).Wait();
            return result;
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesAsync( string bearerToken)
        {
            string requestURI = $"/api/Category/getAll";
            return await SendGet<List<CategoryDTO>>(requestURI, bearerToken);
        }


        // Login y obtener token
        public string Login(string username, string password)
        {
            string token = null;

            try
            {
                // Ejecutar el método asíncrono de forma síncrona
                Task.Run(async () => token = await LoginAsync(username, password)).Wait();
                if (token == "Usuario no encontrado")
                {
                    token = null;
                }
            }
            catch (Exception ex)
            {
            }

            // Si todo va bien, devolver el token
            return token;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var loginData = new
            {
                username = username,
                password = password
            };

            // Ruta de login

            string requestURI = "/api/Login/login";
            requestURI = BaseAddress + requestURI;

            string result = null;

            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var jsonData = JsonConvert.SerializeObject(loginData);
                    HttpResponseMessage response = await client.PostAsync(
                        requestURI,
                        new StringContent(jsonData, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    return $"Usuario no encontrado";
                }
            }

            return result;
        }


        public string Register(string username, string password, string rol, string emailAddress, string firstName, string lastName)
        {
            string resultMessage = "Error desconocido";

            try
            {
                // Ejecutar el método asincrónico de forma síncrona
                Task.Run(async () => resultMessage = await RegisterAsync(username, password, rol, emailAddress, firstName, lastName)).Wait();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                resultMessage = $"Ocurrió un error en el servidor: {ex.Message}";
            }

            return resultMessage;
        }
        public async Task<string> RegisterAsync(string username, string password, string rol, string emailAddress, string firstName, string lastName)
        {
            // Construir la URL completa con los parámetros como query string
            string requestURI = $"/api/Login/register?username={username}&password={password}&rol={rol}&emailAddress={emailAddress}&firstName={firstName}&lastName={lastName}";
            requestURI = BaseAddress + requestURI;
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Realizar la solicitud POST
                    HttpResponseMessage response = await client.PostAsync(requestURI, null);

                    // Leer el contenido de la respuesta
                    string responseContent = await response.Content.ReadAsStringAsync();

                    // Verificar si la respuesta es true (usuario registrado exitosamente)
                    if (responseContent.Trim().ToLower() == "true")
                    {
                        return "Registro exitoso";
                    }
                    else
                    {
                        return "Ya existe un usuario registrado con ese nombre";
                    }
                }
                catch (HttpRequestException ex)
                {
                    return $"Error de conexión: {ex.Message}";
                }
                catch (Exception ex)
                {
                    return $"Ocurrió un error inesperado: {ex.Message}";
                }
            }
        }
        public async Task<bool> VerificarUsuario(string username)
        {
            bool isUserValid = false;
            try
            {
                // Datos para la solicitud de verificación de usuario (solo el nombre de usuario)
                var verifyData = new
                {
                    username = username
                };

                // Llamada a la API de verificación de usuario (endpoint en LoginController)
                string requestURI = "/api/Login/verificarUsuario";  // El endpoint que se definió en LoginController

                // Aquí asumimos que el método SendPost es una implementación que envía una solicitud POST y obtiene la respuesta
                isUserValid = await SendPost<bool, object>(requestURI, verifyData, string.Empty);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error en la verificación del usuario: {ex.Message}");
            }

            return isUserValid;
        }



        public string obtenerCorreo(string username)
        {
            try
            {
                // Construir la URL completa con el username como parámetro
                string requestURI = $"/api/Login/obtenerCorreo?username={username}";
                requestURI = BaseAddress + requestURI;

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Realizar la solicitud GET para obtener el correo
                    HttpResponseMessage response = client.GetAsync(requestURI).Result;

                    // Leer el contenido de la respuesta
                    string responseContent = response.Content.ReadAsStringAsync().Result;

                    // Verificar si la respuesta contiene un correo válido
                    if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(responseContent))
                    {
                        return responseContent.Trim(); // El correo está contenido en la respuesta
                    }
                    else
                    {
                        return "No se encontró el correo para el usuario.";
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return $"Error de conexión: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error inesperado: {ex.Message}";
            }
        }
        //loginattempts
        // Métodos de ILoginAttemptsService
        // Asincrónico
        public async Task<bool> RegisterLoginAttempt(string username)
        {
            var data = new { Username = username };
            return await SendPost<bool, object>("/api/LoginAttempts/Register", data, string.Empty);
        }

        // Sincrónico
        public bool RegisterLoginAttemptSync(string username)
        {
            bool result = false;
            Task.Run(async () => result = await RegisterLoginAttempt(username)).Wait();
            return result;
        }

        // Asincrónico
        public async Task<bool> IsAccountBlocked(string username)
        {
            return await SendGet<bool>($"/api/LoginAttempts/IsBlocked?username={username}", string.Empty);
        }

        // Sincrónico
        public bool IsAccountBlockedSync(string username)
        {
            bool result = false;
            Task.Run(async () => result = await IsAccountBlocked(username)).Wait();
            return result;
        }

        // Asincrónico
        public async Task<bool> UnlockAccount(string username)
        {
            return await SendPost<bool, object>($"/api/LoginAttempts/Unlock?username={username}", null, string.Empty);
        }

        // Sincrónico
        public bool UnlockAccountSync(string username)
        {
            bool result = false;
            Task.Run(async () => result = await UnlockAccount(username)).Wait();
            return result;
        }

        // Asincrónico
        public async Task<bool> ResetLoginAttempts(string username)
        {
            return await SendPost<bool, object>($"/api/LoginAttempts/Reset?username={username}", null, string.Empty);
        }

        // Sincrónico
        public bool ResetLoginAttemptsSync(string username)
        {
            bool result = false;
            Task.Run(async () => result = await ResetLoginAttempts(username)).Wait();
            return result;
        }

        // Asincrónico
        public async Task<List<LoginAttempts>> GetAllLoginAttempts()
        {
            return await SendGet<List<LoginAttempts>>("/api/LoginAttempts/GetAll", string.Empty);
        }

        // Sincrónico
        public List<LoginAttempts> GetAllLoginAttemptsSync()
        {
            List<LoginAttempts> result = null;
            Task.Run(async () => result = await GetAllLoginAttempts()).Wait();
            return result;
        }

        // Asincrónico
        public async Task<LoginAttempts> RetrieveLoginAttemptsByUsername(string username)
        {
            return await SendGet<LoginAttempts>($"/api/LoginAttempts/Retrieve?username={username}", string.Empty);
        }

        // Sincrónico
        public LoginAttempts RetrieveLoginAttemptsByUsernameSync(string username)
        {
            LoginAttempts result = null;
            Task.Run(async () => result = await RetrieveLoginAttemptsByUsername(username)).Wait();
            return result;
        }


    }
}
