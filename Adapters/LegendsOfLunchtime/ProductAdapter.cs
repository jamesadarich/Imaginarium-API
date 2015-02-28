using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.LegendsOfLunchtime
{
    public class ProductAdapter
    {
        public DataTransferObjects.LegendsOfLunchtime.Product AdaptModel(Models.LegendsOfLunchtime.Product product)
        {
            if (product == null)
            {
                return null;
            }

            var dto = new DataTransferObjects.LegendsOfLunchtime.Product();

            dto.Id = product.Id;
            dto.Name = product.Name;
            dto.Ratings = product.Ratings.Select(r => new RatingAdapter().AdaptModel(r));

            dto.Brand = new BrandAdapter().AdaptModel(product.Brand);
            dto.Type = new ProductTypeAdapter().AdaptModel(product.Type);

            return dto;
        }

        public Models.LegendsOfLunchtime.Product AdaptDto(DataTransferObjects.LegendsOfLunchtime.Product product)
        {
            if (product == null)
            {
                return null;
            }

            var model = new Models.LegendsOfLunchtime.Product();
            model.Id = Guid.NewGuid();
            if (product.Id != new Guid())
            {
                model = new DataAccess.LegendsOfLunchtime.Repository().Products.Where(b => b.Id == product.Id).Single();
            }

            model.Name = product.Name;

            model.Brand = new BrandAdapter().AdaptDto(product.Brand);
            model.BrandId = model.Brand.Id;
            model.Type = new ProductTypeAdapter().AdaptModel(product.Type);
            model.ProductTypeId = model.Type.Id;

            if (product.Ratings != null)
            {
                model.Ratings = product.Ratings.Select(r => new RatingAdapter().AdaptDto(r)).ToList();
            }

            return model;
        }
    }
}
