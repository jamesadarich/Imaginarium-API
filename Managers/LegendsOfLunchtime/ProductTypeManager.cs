using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendsOfLunchtime.Managers.Adapters;

namespace LegendsOfLunchtime.Managers
{
    public class ProductTypeManager
    {
        public IEnumerable<DataTransferObjects.ProductType> GetAll()
        {
            var repo = new DataAccess.Repository();

            var productTypes = repo.ProductTypes.ToList();

            return productTypes.Select(p => p.ToDto());
        }
    }
}
