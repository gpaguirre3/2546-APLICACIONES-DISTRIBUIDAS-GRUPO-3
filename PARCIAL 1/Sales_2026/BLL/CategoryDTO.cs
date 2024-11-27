using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryDTO
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        // Relación con productos (esto es opcional dependiendo de cómo quieras manejar la serialización)
        public List<ProductDTO> Products { get; set; }
    }
}
