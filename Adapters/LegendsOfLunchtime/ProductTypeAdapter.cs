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

            model.Id = productType.Id;
            model.Name = productType.Name;
            model.RatingTypes = productType.RatingTypes.Select(r => new RatingTypeAdapter().AdaptDto(r)).ToList();

            return model;
        }
    }
}
