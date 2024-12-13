using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositoryFactory
    {
        public static IRepository CreateRepository()
        {
            //retornamos una nueva instancia de entityframeworkrepositiry
            //pasamos el contexto de la base de datos
            return new EFRepository(new Entities.Sales_DBEntities());
        }
    }
}
