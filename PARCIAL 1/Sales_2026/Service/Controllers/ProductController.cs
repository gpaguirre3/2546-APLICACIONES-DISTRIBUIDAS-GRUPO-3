using BLL;
using Entities;
using SLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace Service.Controllers
{
    public class ProductController : ApiController, IProductService
    {
        [HttpPost]
        public Products CreateProduct(Products products)
        {
            var productsLogic = new ProductLogic();
            var product=productsLogic.Create(products);
            return product;
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            var productsLogic = new ProductLogic();
            var product = productsLogic.Delete(id);
            return product;
        }

        [HttpGet]
        public List<Products> Filter(string name)
        {
            var productsLogic=new ProductLogic();
            var product=productsLogic.Filter(name);
            return product;
        }
        //DTO
        [HttpGet]
        public List<ProductDTO> FilterProducts(string name)
        {
            var productsLogic = new ProductLogic();
            var product = productsLogic.FilterProducts(name);
            return product;
        }
        //no implementado
        public List<Products> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Products RetrieveProductById(int id)
        {
            // Llamamos al método de la lógica para buscar un producto por ID
            var productsLogic = new ProductLogic();
            var product = productsLogic.RetrieveById(id);
            return product;
        }
        //DTO
        [HttpGet]
        public ProductDTO GetProductById(int id)
        {
            // Llamamos al método de la lógica para buscar un producto por ID
            var productsLogic = new ProductLogic();
            var product = productsLogic.GetProductById(id);
            return product;
        }
        [HttpPut]
        public bool UpdateProduct(Products productToUpdate)
        {
            var productsLogic = new ProductLogic();
            var product = productsLogic.Update(productToUpdate);
            return product;
        }
    }
}
