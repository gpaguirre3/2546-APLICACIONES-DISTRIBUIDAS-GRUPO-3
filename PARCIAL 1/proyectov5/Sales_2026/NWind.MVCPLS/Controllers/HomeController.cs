using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NWindProxyService1;
using System.Text.RegularExpressions;

public class HomeController : Controller
{
    public System.Web.Mvc.ActionResult Index()
    {
        // Verificar si la cookie existe
        if (Request.Cookies["AuthToken"] != null)
        {
            // Crear una cookie con el mismo nombre y una fecha de expiración pasada
            var cookie = new HttpCookie("AuthToken")
            {
                Expires = System.DateTime.Now.AddDays(-1), // Fecha de expiración en el pasado
                Value = null
            };
            // Agregarla a la respuesta para que se elimine
            Response.Cookies.Add(cookie);
        }

        // Retornar la vista
        return View();
    }
    //metodo para sanitizar
    public static class SanitizerHelper
    {
        public static string SanitizeInput(string input)
        {
            return Microsoft.Security.Application.Sanitizer.GetSafeHtmlFragment(input ?? string.Empty);
        }
    }

    //metodo index con db
    [System.Web.Mvc.HttpPost]
    [ValidateAntiForgeryToken]
    public System.Web.Mvc.ActionResult Index(string username, string password)
    {
        username = SanitizerHelper.SanitizeInput(username);
        password = SanitizerHelper.SanitizeInput(password);
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ViewBag.Message = "Por favor, ingrese su usuario y contraseña.";
            return View();
        }
        var userLogic = new UserLogic();
        if (!userLogic.UsernameExists(username))
        {
            // Si no existe, devolver mensaje de credenciales inválidas sin crear registros
            ViewBag.Message = "Credenciales incorrectas. Intente nuevamente.";
            return View();
        }

        var loginAttemptsLogic = new LoginAttemptsLogic();

        // Verificar si el registro existe, si no, crear uno
        if (!loginAttemptsLogic.UserExists(username))
        {
            loginAttemptsLogic.CreateUserRecord(username);
        }

        // Verificar si la cuenta está bloqueada
        if (loginAttemptsLogic.IsAccountBlocked(username))
        {
            ViewBag.Message = "Demasiados intentos fallidos. Por favor, espere 5 minutos.";
            return View();
        }

        // Proceder con la lógica de autenticación
        var proxy = new Proxy();
        var token = proxy.Login(username, password);

        if (!string.IsNullOrEmpty(token))
        {
            // Si el login es exitoso, reiniciar los intentos
            loginAttemptsLogic.ResetLoginAttempts(username);

            // Crear la cookie de autenticación
            HttpCookie authCookie = new HttpCookie("AuthToken", token)
            {
                Expires = DateTime.Now.AddMinutes(30),
                HttpOnly = true,
                Secure = true
            };
            Response.Cookies.Add(authCookie);

            return RedirectToAction("Menu", "Home");
        }
        else
        {
            // Incrementar intentos fallidos
            bool isBlocked = loginAttemptsLogic.RegisterLoginAttempt(username);

            if (isBlocked)
            {
                ViewBag.Message = "Demasiados intentos fallidos. Por favor, espere 5 minutos.";
                string email = proxy.obtenerCorreo(username);
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!string.IsNullOrEmpty(email) && Regex.IsMatch(email, emailPattern))
                {
                    email = email.Replace("\"", "").Replace("'", "");
                    Utils utils = new Utils();
                    utils.EnviarCorreo(email,
                        "Intento de acceso a tu cuenta",
                        "Hola,\n\nAlguien ha intentado acceder a tu cuenta. Si no fuiste tú, por favor, toma las medidas necesarias.");

                }
            }
            else
            {
                ViewBag.Message = "Credenciales incorrectas. Intente nuevamente.";
            }
        }

        return View();
    }
    // GET: Menu - Página de menú
    public System.Web.Mvc.ActionResult Menu()
    {
        // Recuperar el token desde la cookie
        var token = Request.Cookies["AuthToken"]?.Value;

        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Index");  // Si no hay token, redirigir al login
        }

        // Aquí puedes pasar cualquier dato necesario a la vista de menú
        return View();
    }
    // GET: Categorias - Página de gestión de categorías
    // GET: Categorias - Página de gestión de categorías
    public System.Web.Mvc.ActionResult Categorias()
    {
        var token = GetAuthToken();
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    [System.Web.Mvc.HttpPost]
    [ValidateAntiForgeryToken]
    public System.Web.Mvc.ActionResult Categorias(string nombre, string descripcion)
    {
        nombre = SanitizerHelper.SanitizeInput(nombre);
        descripcion = SanitizerHelper.SanitizeInput(descripcion);
        var token = GetAuthToken();
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Index"); // Redirigir al login si no hay token
        }

        try
        {
            var proxy = new Proxy();
            var newCategory = new CategoryDTO
            {
                CategoryName = nombre,
                Description = descripcion
            };

            var result = proxy.CreateCategoryDTO(newCategory, token);

            if (result.CategoryName == "Error")
            {
                ViewBag.Message = $"No se encuentra autorizado a crear una categoría o ya existe una categoría con ese nombre.";
            }
            else
            {
                ViewBag.Message = "Categoría creada exitosamente.";
            }
        }
        catch (Exception ex)
        {
            ViewBag.Message = $"Error inesperado: {ex.Message}";
        }

        return View();
    }


    // Método para buscar categorías por nombre
    [System.Web.Mvc.HttpGet]
    public System.Web.Mvc.ActionResult BuscarCategorias(string nombre)
    {
        nombre = SanitizerHelper.SanitizeInput(nombre);
        var token = GetAuthToken();
        if (string.IsNullOrEmpty(token))
        {
            return Json(new { error = "No autorizado" }, JsonRequestBehavior.AllowGet);
        }

        try
        {
            var proxy = new Proxy();

            // Intentar buscar por nombre
            var categoriasPorNombre = proxy.FilterCategoriesByName(nombre, token);

            // Intentar buscar por ID, si el nombre es un número válido
            List<CategoryDTO> categoriasPorId = new List<CategoryDTO>();
            if (int.TryParse(nombre, out int id))
            {
                var categoriaPorId = proxy.GetCategoryById(id, token);
                if (categoriaPorId != null)
                {
                    categoriasPorId.Add(categoriaPorId);
                }
            }

            // Combinar los resultados
            var categoriasCombinadas = categoriasPorNombre?.Union(categoriasPorId).ToList();

            // Si no se encontraron categorías por nombre ni por ID
            if (categoriasCombinadas == null || categoriasCombinadas.Count == 0)
            {
                return Json(new { error = "No se encontraron categorías relacionadas con la búsqueda." }, JsonRequestBehavior.AllowGet);
            }

            return Json(categoriasCombinadas, JsonRequestBehavior.AllowGet);
        }
        catch (Exception ex)
        {
            // Manejar errores generales
            return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
        }
    }



    // Método para obtener categoría por ID
    [System.Web.Mvc.HttpGet]
    public System.Web.Mvc.ActionResult ObtenerCategoriaPorId(int id)
    {
        var token = GetAuthToken();
        if (string.IsNullOrEmpty(token))
        {
            return Json(new { error = "No autorizado" }, JsonRequestBehavior.AllowGet);
        }

        try
        {
            var proxy = new Proxy();
            var categoria = proxy.GetCategoryById(id, token);
            return Json(categoria, JsonRequestBehavior.AllowGet);
        }
        catch (Exception ex)
        {
            return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
        }
    }

    // Método para actualizar categoría
    [System.Web.Mvc.HttpPost]
    public System.Web.Mvc.ActionResult ActualizarCategoria([FromBody] CategoryDTO categoria)
    {
        var token = GetAuthToken();
        if (string.IsNullOrEmpty(token))
        {
            return Json(new { success = false, message = "No autorizado" });
        }

        try
        {
            var proxy = new Proxy();
            var result = proxy.UpdateCategory(categoria, token);

            return Json(new
            {
                success = result,
                message = result ? "Actualización exitosa" : "Error al actualizar"
            });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }

    // Método para eliminar categoría
    [System.Web.Mvc.HttpPost]
    public System.Web.Mvc.ActionResult EliminarCategoria(int id)
    {
        var token = GetAuthToken();
        if (string.IsNullOrEmpty(token))
        {
            return Json(new { success = false, message = "No autorizado" });
        }

        try
        {
            var proxy = new Proxy();
            var result = proxy.DeleteCategory(id, token);

            return Json(new
            {
                success = result,
                message = result ? "Eliminación exitosa" : "Error al eliminar: verifique que se encuentre autorizado o que la categoría no contenga productos."
            });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }

    // Método para obtener el token de autenticación desde la cookie
    private string GetAuthToken()
    {
        var token = Request.Cookies["AuthToken"]?.Value;

        // Verifica si el token no es nulo y remueve las comillas si están presentes
        return token?.Trim('"');
    }

    // GET: Productos - Página de gestión de productos
    public System.Web.Mvc.ActionResult Productos()
    {
        var token = Request.Cookies["AuthToken"]?.Value;

        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Index");  // Si no hay token, redirigir al login
        }

        return View();  // Devuelve la vista Productos.cshtml
    }

    // Método para crear un nuevo producto
    [System.Web.Mvc.HttpPost]
    public System.Web.Mvc.ActionResult Productos(string productName, int categoryId, decimal unitPrice, int unitsInStock)
    {
        productName = SanitizerHelper.SanitizeInput(productName);
        var token = GetAuthToken();
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Index"); // Redirigir al login si no hay token
        }

        try
        {
            var proxy = new Proxy();
            var newProduct = new ProductDTO
            {
                ProductName = productName,
                CategoryID = categoryId,
                UnitPrice = unitPrice,
                UnitsInStock = unitsInStock
            };

            var result = proxy.CreateProductDTO(newProduct, token);

            if (result == null)
            {
                ViewBag.Message = "Error al crear el producto verifique que se encuentre autorizado o que el nombre del producto no exista.";
            }
            else
            {
                ViewBag.Message = "Producto creado exitosamente.";
            }
        }
        catch (Exception ex)
        {
            ViewBag.Message = $"Error inesperado: {ex.Message}";
        }

        return View(); // Redirige de vuelta a la vista actual
    }

    // Método para buscar productos por nombre o ID
    [System.Web.Mvc.HttpGet]
    public System.Web.Mvc.ActionResult BuscarProductos(string nombre)
    {
        nombre = SanitizerHelper.SanitizeInput(nombre);
        var token = GetAuthToken();
        if (string.IsNullOrEmpty(token))
        {
            return Json(new { error = "No autorizado" }, JsonRequestBehavior.AllowGet);
        }

        try
        {
            var proxy = new Proxy();

            // Buscar productos por nombre
            var productosPorNombre = proxy.FilterProductsDTOByName(nombre, token);

            // Intentar buscar por ID, si el nombre es un número válido
            List<ProductDTO> productosPorId = new List<ProductDTO>();
            if (int.TryParse(nombre, out int id))
            {
                var productoPorId = proxy.RetrieveProductByID(id, token);
                if (productoPorId != null)
                {
                    productosPorId.Add(productoPorId);
                }
            }

            // Combinar los resultados
            var productosCombinados = productosPorNombre?.Union(productosPorId).ToList();

            // Si no se encontraron productos
            if (productosCombinados == null || productosCombinados.Count == 0)
            {
                return Json(new { error = "No se encontraron productos relacionados con la búsqueda." }, JsonRequestBehavior.AllowGet);
            }

            return Json(productosCombinados, JsonRequestBehavior.AllowGet);
        }
        catch (Exception ex)
        {
            return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
        }
    }


    // Método para buscar productos por ID
    [System.Web.Mvc.HttpGet]
    public System.Web.Mvc.ActionResult BuscarProductosCategoria(string id)
    {
        var token = GetAuthToken();
        if (string.IsNullOrEmpty(token))
        {
            return Json(new { error = "No autorizado" }, JsonRequestBehavior.AllowGet);
        }

        try
        {
            // Verificar si el ID es un número válido
            if (!int.TryParse(id, out int productId))
            {
                return Json(new { error = "El ID proporcionado no es válido." }, JsonRequestBehavior.AllowGet);
            }

            var proxy = new Proxy();

            // Buscar el producto por ID
            var producto = proxy.FilterProductsDTOByCategoryID(productId, token);

            // Si no se encuentra el producto
            if (producto == null)
            {
                return Json(new { error = "No se encontró el producto con el ID proporcionado." }, JsonRequestBehavior.AllowGet);
            }

            return Json(producto, JsonRequestBehavior.AllowGet);
        }
        catch (Exception ex)
        {
            return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
        }
    }



    // Método para obtener producto por ID
    [System.Web.Mvc.HttpGet]
    public System.Web.Mvc.ActionResult ObtenerProductoPorId(int id)
    {
        var token = GetAuthToken();
        if (string.IsNullOrEmpty(token))
        {
            return Json(new { error = "No autorizado" }, JsonRequestBehavior.AllowGet);
        }

        try
        {
            var proxy = new Proxy();
            var producto = proxy.RetrieveProductByID(id, token);
            return Json(producto, JsonRequestBehavior.AllowGet);
        }
        catch (Exception ex)
        {
            return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
        }
    }

    // Método para actualizar un producto
    [System.Web.Mvc.HttpPost]
    public System.Web.Mvc.ActionResult ActualizarProducto([FromBody] ProductDTO producto)
    {
        var token = GetAuthToken();
        if (string.IsNullOrEmpty(token))
        {
            return Json(new { success = false, message = "No autorizado" });
        }

        try
        {
            var proxy = new Proxy();
            var result = proxy.UpdateProductDTO(producto, token);

            return Json(new
            {
                success = result,
                message = result ? "Actualización exitosa" : "Error al actualizar"
            });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }

    // Método para eliminar un producto
    [System.Web.Mvc.HttpPost]
    public System.Web.Mvc.ActionResult EliminarProducto(int id)
    {
        var token = GetAuthToken();
        if (string.IsNullOrEmpty(token))
        {
            return Json(new { success = false, message = "No autorizado" });
        }

        try
        {
            var proxy = new Proxy();
            var result = proxy.DeleteProduct(id, token);

            return Json(new
            {
                success = result,
                message = result ? "Eliminación exitosa" : "Error al eliminar"
            });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }

    // Método para obtener todas las categorías
    [System.Web.Mvc.HttpGet]
    public System.Web.Mvc.ActionResult ObtenerCategorias()
    {
        var token = GetAuthToken();
        if (string.IsNullOrEmpty(token))
        {
            return Json(new { success = false, message = "No autorizado" }, JsonRequestBehavior.AllowGet);
        }

        try
        {
            var proxy = new Proxy();
            var categorias = proxy.GetAllCategories(token); // Método que obtiene todas las categorías

            // Filtrar las categorías para devolver solo CATEGORYID y CATEGORYNAME
            var categoriasFiltradas = categorias.Select(c => new
            {
                CATEGORYID = c.CategoryID,
                CATEGORYNAME = c.CategoryName
            }).ToArray();

            return Json(new
            {
                success = true,
                categorias = categoriasFiltradas
            }, JsonRequestBehavior.AllowGet);
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
        }
    }




}
