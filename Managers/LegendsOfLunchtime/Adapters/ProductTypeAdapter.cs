using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfLunchtime.Managers.Adapters
{
    public static class ProductTypeAdapter
    {
        public static DataTransferObjects.ProductType ToDto(this Models.ProductType productType)
        {
            if (productType == null)
            {
                return null;
            }

            var dto = new DataTransferObjects.ProductType();

            dto.Id = productType.Id;
            dto.Name = productType.Name;
            dto.RatingTypes = productType.RatingTypes.Select(r => r.ToDto());

            return dto;
        }

        public static Models.ProductType ToModel(this DataTransferObjects.ProductType productType, DataAccess.Repository repository)
        {
            if (productType == null)
            {
                return null;
            }
            var model = new Models.ProductType();
            model.Id = Guid.NewGuid();
            if (productType.Id != new Guid())
            {
                model = repository.ProductTypes.Where(b => b.Id == productType.Id).Single();
            }

            model.Name = productType.Name;
            if (productType.RatingTypes != null)
            {
                model.RatingTypes = productType.RatingTypes.Select(r => r.ToModel(repository)).ToList();
            }
            else
            {
                productType.RatingTypes = null;
            }

            return model;
        }
    }
}
