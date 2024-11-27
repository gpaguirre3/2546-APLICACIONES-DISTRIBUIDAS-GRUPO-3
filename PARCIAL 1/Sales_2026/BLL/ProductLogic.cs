using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductLogic
    {
        //agregamos metodos con logica
        public Products Create(Products products)
        {
            Products res = null;
            //no se puede insertar un producto con el mismo nombre
            using (var r= RepositoryFactory.CreateRepository())
            {
                //me busca que tenga el mismo nombre
                Products result = r.Retrieve<Products>(p=>p.ProductName==products.ProductName);
                if(result == null)
                {
                    res = r.Create(products);
                }
                else
                {
                    //la logica en caso de que exista el producto
                }
                return res;
            }
        }
        //metodo para buscar
        public Products RetrieveById(int id)
        {
            Products res = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                res = r.Retrieve<Products>(p => p.ProductID== id);

            }
            return res;

        }
        //metodo actualizar
        public bool Update(Products productToUpdate)
        {
            bool res = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                //validar que el nombre de producto no exista
                Products temp= r.Retrieve<Products>(p=>p.ProductName==productToUpdate.ProductName &&
                p.ProductID!=productToUpdate.ProductID);
                if(temp == null)
                {
                    res=r.Update(productToUpdate);
                }
                else
                {
                    // 
                }
            }
            return res;

        }
        //metodo eliminar
        public bool Delete(int id)
        {
            bool res = false;
            //no elminiar si tiene existencias
            var product=RetrieveById(id);
            if (product != null)
            {
                if (product.UnitsInStock != 0)
                {
                    using (var r = RepositoryFactory.CreateRepository())
                    {
                        //res |= r.Delete(product);
                        res = r.Delete(product);

                    }

                }
                else
                {
                    //todavia existen productos en stock
                }
            }
            else
            {
                // logica de producto que no existe
            }            
            return res;
        }
        //filtrar por nombre
        public List<Products> Filter(string name)
        {
            List<Products> res = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                //res |= r.Delete(product);
                res = r.Filter<Products>(p=>p.ProductName==name);

            }
            return res;
        }
        //DTO
        public ProductDTO GetProductById(int id)
        {
            ProductDTO productDTO = null;

            using (var r = RepositoryFactory.CreateRepository())
            {
                // Recupera el producto por su ID
                var product = r.Retrieve<Products>(p => p.ProductID == id);

                if (product != null)
                {
                    // Mapeo manual del producto a DTO
                    productDTO = new ProductDTO
                    {
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,
                        UnitPrice = product.UnitPrice,
                        UnitsInStock = product.UnitsInStock,
                        CategoryID = product.CategoryID,
                        CategoryName = product.Categories.CategoryName // Relacionamos la categoría
                    };
                }
            }

            return productDTO;
        }
        //dto
        public List<ProductDTO> FilterProducts(string name)
        {
            List<ProductDTO> res = null;

            using (var r = RepositoryFactory.CreateRepository())
            {
                // Filtra los productos por nombre
                var products = r.Filter<Products>(p => p.ProductName.Contains(name));

                // Mapea los productos a ProductDTO
                res = products.Select(p => new ProductDTO
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock,
                    CategoryID = p.CategoryID,
                    CategoryName = p.Categories.CategoryName  // Relaciona el nombre de la categoría
                }).ToList();
            }

            return res;
        }


    }
}
