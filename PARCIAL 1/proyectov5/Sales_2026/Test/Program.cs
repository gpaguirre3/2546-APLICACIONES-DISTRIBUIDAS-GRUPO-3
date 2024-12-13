using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            addCategoryAndProduct();
        }
        static void addCategoryAndProduct()
        {
            var categories = new Categories();
            categories.CategoryName = "Test 2";
            categories.Description = "Despcripcion Test 2";
            var product= new Products();
            product.ProductName = "Ají";
            product.UnitPrice = 5;
            product.UnitsInStock = 500;
            categories.Products.Add(product);
            //utilizar el contexto
            using (var repository = RepositoryFactory.CreateRepository())
            {
                repository.Create(categories);
            }
            Console.WriteLine($"Categoria: {categories.CategoryID}, Product: {product.ProductID}");
            Console.ReadLine();

        }
    }
}
