using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    //[Serializable]
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int CategoryID { get; set; }  // Este campo puede ser opcional si deseas enviar solo el ID
        public string CategoryName { get; set; }  // Si deseas incluir el nombre de la categoría
    }
}
