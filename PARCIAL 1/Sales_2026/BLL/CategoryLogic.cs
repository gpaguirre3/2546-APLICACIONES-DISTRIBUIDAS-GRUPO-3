using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryLogic
    {
        // Método para crear una categoría
        public Categories Create(Categories category)
        {
            Categories res = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Verificar que no exista una categoría con el mismo nombre
                Categories existingCategory = r.Retrieve<Categories>(c => c.CategoryName == category.CategoryName);
                if (existingCategory == null)
                {
                    res = r.Create(category);
                }
                else
                {
                    // Lógica en caso de que la categoría ya exista
                    throw new Exception("La categoría ya existe.");
                }
            }
            return res;
        }

        // Método para buscar una categoría por ID
        public Categories RetrieveById(int id)
        {
            Categories res = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                res = r.Retrieve<Categories>(c => c.CategoryID == id);
                
            }
            return res;
        }
        // Método para obtener una categoría con los productos DTO
        public CategoryDTO GetCategoryById(int id)
        {
            CategoryDTO categoryDTO = null;

            using (var r = RepositoryFactory.CreateRepository())
            {
                // Recupera la categoría con los productos relacionados
                var category = r.Retrieve<Categories>(c => c.CategoryID == id);
                            

                if (category != null)
                {
                    // Mapeo manual de la categoría a DTO
                    categoryDTO = new CategoryDTO
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        Description = category.Description,
                        Products = category.Products.Select(p => new ProductDTO
                        {
                            ProductID = p.ProductID,
                            ProductName = p.ProductName,
                            UnitPrice = p.UnitPrice,
                            UnitsInStock = p.UnitsInStock,
                            CategoryID = p.CategoryID,
                            //CategoryName = p.Category.CategoryName  // Si deseas incluir el nombre de la categoría
                        }).ToList()
                    };
                }
            }

            return categoryDTO;
        }
        //DTO
        // Método para filtrar categorías por nombre
        public List<CategoryDTO> Filter1(string name)
        {
            List<CategoryDTO> res = null;

            using (var r = RepositoryFactory.CreateRepository())
            {
                // Filtra las categorías por nombre
                var categories = r.Filter<Categories>(c => c.CategoryName.Contains(name));

                // Mapea las categorías a CategoryDTO
                res = categories.Select(c => new CategoryDTO
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                    Products=c.Products.Select(p => new ProductDTO
                    {
                        ProductID = p.ProductID,
                        ProductName = p.ProductName,
                        UnitPrice = p.UnitPrice,
                        UnitsInStock = p.UnitsInStock,
                        CategoryID = p.CategoryID

                    }).ToList()
                }).ToList();
            }

            return res;
        }



        // Método para actualizar una categoría
        public int Update(Categories categoryToUpdate)
        {
            bool res = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Validar que no haya otra categoría con el mismo nombre
                Categories existingCategory = r.Retrieve<Categories>(
                    c => c.CategoryName == categoryToUpdate.CategoryName &&
                         c.CategoryID != categoryToUpdate.CategoryID);
                if (existingCategory == null)
                {
                    res = r.Update(categoryToUpdate);
                }
                else
                {
                    // Lógica en caso de que el nombre ya esté en uso
                    throw new Exception("Ya existe otra categoría con el mismo nombre.");
                }
            }
            return 1;
        }
        //UPDATE DTO
        public bool UpdateDTO(CategoryDTO categoryToUpdate)
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Mapear el objeto CategoryDTO a la entidad Categories
                var categoryEntity = new Categories
                {
                    CategoryID = categoryToUpdate.CategoryID,
                    CategoryName = categoryToUpdate.CategoryName,
                    Description = categoryToUpdate.Description
                };

                // Validar que no haya otra categoría con el mismo nombre
                Categories existingCategory = r.Retrieve<Categories>(
                    c => c.CategoryName == categoryEntity.CategoryName &&
                         c.CategoryID != categoryEntity.CategoryID);

                if (existingCategory == null)
                {
                    // Actualizar la categoría en la base de datos
                    bool result = r.Update(categoryEntity);

                    // Devolver un indicador de éxito
                    return result;
                }
                else
                {
                    // Lógica en caso de que el nombre ya esté en uso
                    throw new Exception("Ya existe otra categoría con el mismo nombre.");
                }
            }
        }


        // Método para eliminar una categoría
        public bool Delete(int id)
        {
            bool res = false;
            // Verificar que no existan productos asociados a la categoría
            using (var r = RepositoryFactory.CreateRepository())
            {
                var products = r.Filter<Products>(p => p.CategoryID == id);
                if (products == null || products.Count == 0)
                {
                    var category = RetrieveById(id);
                    if (category != null)
                    {
                        res = r.Delete(category);
                    }
                    else
                    {
                        throw new Exception("La categoría no existe.");
                    }
                }
                else
                {
                    // Lógica en caso de que haya productos asociados
                    throw new Exception("No se puede eliminar la categoría porque tiene productos asociados.");
                }
            }
            return res;
        }

        // Método para filtrar categorías por nombre
        public List<Categories> Filter(string name)
        {
            List<Categories> res = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                res = r.Filter<Categories>(c => c.CategoryName.Contains(name));
            }
            return res;
        }
        public CategoryDTO CreateDTO(CategoryDTO categoryDTO)
        {
            CategoryDTO res = null;

            using (var r = RepositoryFactory.CreateRepository())
            {
                // Mapear el objeto CategoryDTO a la entidad Categories
                var categoryEntity = new Categories
                {
                    CategoryName = categoryDTO.CategoryName,
                    Description = categoryDTO.Description
                };

                // Verificar que no exista una categoría con el mismo nombre
                Categories existingCategory = r.Retrieve<Categories>(c => c.CategoryName == categoryEntity.CategoryName);
                if (existingCategory == null)
                {
                    // Crear la categoría en la base de datos
                    Categories createdCategory = r.Create(categoryEntity);

                    // Mapear el resultado a CategoryDTO
                    res = new CategoryDTO
                    {
                        CategoryID = createdCategory.CategoryID, // Asignar el ID generado
                        CategoryName = createdCategory.CategoryName,
                        Description = createdCategory.Description,
                        Products = new List<ProductDTO>() // Lista vacía ya que la categoría no tiene productos al crearse
                    };
                }
                else
                {
                    // Lógica en caso de que la categoría ya exista
                    throw new Exception("La categoría ya existe.");
                }
            }

            return res;
        }




    }
}
