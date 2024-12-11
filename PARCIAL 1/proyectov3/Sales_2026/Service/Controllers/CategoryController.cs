using BLL;
using Entities;
using SLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers
{
    public class CategoryController : ApiController, ICategoryService
    {
        [HttpPost]
        public Categories Create(Categories category)
        {
            var categoryLogic = new CategoryLogic();
            var createdCategory = categoryLogic.Create(category);
            return createdCategory;
        }
        [HttpPost]

        public CategoryDTO CreateDTO(CategoryDTO category)
        {
            var categoryLogic = new CategoryLogic();
            var createdCategory = categoryLogic.CreateDTO(category);
            return createdCategory;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var categoryLogic = new CategoryLogic();
            var result = categoryLogic.Delete(id);
            return result;
        }

        [HttpGet]
        public List<Categories> Filter(string name)
        {
            var categoryLogic = new CategoryLogic();
            var categories = categoryLogic.Filter(name);
            return categories;
        }
        [HttpGet]

        public List<CategoryDTO> FilterDTO(string name)
        {
            var categoryLogic = new CategoryLogic();
            var categories = categoryLogic.Filter1(name);
            return categories;
        }

        [HttpGet]
        public Categories RetrieveById(int id)
        {
            var categoryLogic = new CategoryLogic();
            var category = categoryLogic.RetrieveById(id);
            return category;
        }

        [HttpGet]
        public List<CategoryDTO> GetAll()
        {
            var categoryLogic = new CategoryLogic();
            var categories = categoryLogic.GetAllDTO();
            return categories;
        }
        //metodo con dto
        [HttpGet]
        public CategoryDTO GetCategoryById(int id)
        {
            var categoryLogic = new CategoryLogic();
            var category = categoryLogic.GetCategoryById(id);
            return category;
        }

        [HttpPut]
        public int Update(Categories categoryToUpdate)
        {
            var categoryLogic = new CategoryLogic();
            var result = categoryLogic.Update(categoryToUpdate);
            return 1;
        }
        [HttpPut]
        public bool UpdateDTO(CategoryDTO categoryToUpdate)
        {
            var categoryLogic = new CategoryLogic();
            var result = categoryLogic.UpdateDTO(categoryToUpdate);
            return result;
        }

        //Obtener todas las categorias

    }
}
