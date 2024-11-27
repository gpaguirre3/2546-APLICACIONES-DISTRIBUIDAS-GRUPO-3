using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC
{
    public interface ICategoryService
    {
        // Crear una nueva categoría
        Categories Create(Categories category);

        // Buscar una categoría por su ID
        Categories RetrieveById(int id);
        //DTO
       

        // Actualizar una categoría existente
        bool Update(Categories categoryToUpdate);

        // Eliminar una categoría por su ID
        bool Delete(int id);

        // Filtrar categorías por nombre
        List<Categories> Filter(string name);
    }
}
