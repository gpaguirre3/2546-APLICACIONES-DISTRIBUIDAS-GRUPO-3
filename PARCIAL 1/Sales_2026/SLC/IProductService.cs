using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC
{
    public interface IProductService
    {
        // Crear un nuevo producto
        Products CreateProduct(Products products);
        //eliminar un producto por ID
        bool Delete(int id);
        
       

        // Buscar un producto por su ID
        Products RetrieveProductById(int id);

        // Actualizar un producto existente
        bool UpdateProduct(Products productToUpdate);

        

        // Filtrar productos por nombre
        List<Products> Filter(string name);

        // Obtener todos los productos
        List<Products> GetAllProducts();

       
    }
}
