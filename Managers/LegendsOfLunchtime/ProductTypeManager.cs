using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.LegendsOfLunchtime
{
    public class ProductTypeManager
    {
        public IEnumerable<DataTransferObjects.LegendsOfLunchtime.ProductType> GetAll()
        {
            var repo = new DataAccess.LegendsOfLunchtime.Repository();

            var productTypes = repo.ProductTypes.ToList();

            return productTypes.Select(p => new Adapters.LegendsOfLunchtime.ProductTypeAdapter().AdaptModel(p));
        }
    }
}
