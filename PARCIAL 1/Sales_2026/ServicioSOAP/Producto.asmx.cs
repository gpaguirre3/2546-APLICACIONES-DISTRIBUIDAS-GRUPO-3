using BLL;
using Entities;
using System.Collections.Generic;
using System.Web.Services;

namespace ServicioSOAP
{
    /// <summary>
    /// Servicio SOAP para gestionar Productos y Categorías.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Producto : WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        // Métodos para Productos
        //[WebMethod]
        /*public Products RetrieveProductById(int id)
        {
            var productsLogic = new ProductLogic();
            return productsLogic.RetrieveById(id);
        }*/

        [WebMethod]
        public ProductDTO GetProductById(int id)
        {
            var productsLogic = new ProductLogic();
            return productsLogic.GetProductById(id);
        }

        [WebMethod]
        public bool DeleteProduct(int id)
        {
            var productsLogic = new ProductLogic();
            return productsLogic.Delete(id);
        }

        //[WebMethod]
        /*public List<Products> FilterProducts(string name)
        {
            var productsLogic = new ProductLogic();
            return productsLogic.Filter(name);
        }*/

        [WebMethod]
        public List<ProductDTO> FilterProductsDTO(string name)
        {
            var productsLogic = new ProductLogic();
            return productsLogic.FilterProducts(name);
        }

        /*[WebMethod]
        public Products CreateProduct(Products product)
        {
            var productsLogic = new ProductLogic();
            return productsLogic.Create(product);
        }*/

        [WebMethod]
        public ProductDTO CreateProductDTO(ProductDTO product)
        {
            var productsLogic = new ProductLogic();
            return productsLogic.CreateDTO(product);
        }

        //[WebMethod]
        /*public bool UpdateProduct(Products product)
        {
            var productsLogic = new ProductLogic();
            return productsLogic.Update(product);
        }*/

        [WebMethod]
        public bool UpdateProductDTO(ProductDTO product)
        {
            var productsLogic = new ProductLogic();
            return productsLogic.UpdateDTO(product);
        }

        // Métodos para Categorías
        //[WebMethod]
        /*public Categories RetrieveCategoryById(int id)
        {
            var categoryLogic = new CategoryLogic();
            return categoryLogic.RetrieveById(id);
        }*/

        [WebMethod]
        public CategoryDTO GetCategoryById(int id)
        {
            var categoryLogic = new CategoryLogic();
            return categoryLogic.GetCategoryById(id);
        }

        [WebMethod]
        public bool DeleteCategory(int id)
        {
            var categoryLogic = new CategoryLogic();
            return categoryLogic.Delete(id);
        }

        /*[WebMethod]
        public List<Categories> FilterCategories(string name)
        {
            var categoryLogic = new CategoryLogic();
            return categoryLogic.Filter(name);
        }*/

        [WebMethod]
        public List<CategoryDTO> FilterCategoryDTO(string name)
        {
            var categoryLogic = new CategoryLogic();
            return categoryLogic.Filter1(name);
        }

        //[WebMethod]
        /*public Categories CreateCategory(Categories category)
        {
            var categoryLogic = new CategoryLogic();
            return categoryLogic.Create(category);
        }*/

        [WebMethod]
        public CategoryDTO CreateCategoryDTO(CategoryDTO category)
        {
            var categoryLogic = new CategoryLogic();
            return categoryLogic.CreateDTO(category);
        }

        //[WebMethod]
        /*public bool UpdateCategory(Categories category)
        {
            var categoryLogic = new CategoryLogic();
            return categoryLogic.Update(category) > 0;
        }*/

        [WebMethod]
        public bool UpdateCategoryDTO(CategoryDTO category)
        {
            var categoryLogic = new CategoryLogic();
            return categoryLogic.UpdateDTO(category);
        }
    }
}
