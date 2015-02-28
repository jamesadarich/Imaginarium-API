using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.LegendsOfLunchtime
{
    public class ProductTypeAdapter
    {
        public DataTransferObjects.LegendsOfLunchtime.ProductType AdaptModel(Models.LegendsOfLunchtime.ProductType productType)
        {
            if (productType == null)
            {
                return null;
            }

            var dto = new DataTransferObjects.LegendsOfLunchtime.ProductType();

            dto.Id = productType.Id;
            dto.Name = productType.Name;
            dto.RatingTypes = productType.RatingTypes.Select(r => new RatingTypeAdapter().AdaptModel(r));

            return dto;
        }

        public Models.LegendsOfLunchtime.ProductType AdaptModel(DataTransferObjects.LegendsOfLunchtime.ProductType productType)
        {
            if (productType == null)
            {
                return null;
            }
            var model = new Models.LegendsOfLunchtime.ProductType();
            model.Id = Guid.NewGuid();
            if (productType.Id != new Guid())
            {
                model = new DataAccess.LegendsOfLunchtime.Repository().ProductTypes.Where(b => b.Id == productType.Id).Single();
            }

            model.Name = productType.Name;
            if (productType.RatingTypes != null)
            {
                model.RatingTypes = productType.RatingTypes.Select(r => new RatingTypeAdapter().AdaptDto(r)).ToList();
            }
            else
            {
                productType.RatingTypes = null;
            }

            return model;
        }
    }
}
