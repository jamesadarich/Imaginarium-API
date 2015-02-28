using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfLunchtime.Managers.Adapters
{
    public static class ProductAdapter
    {
        public static DataTransferObjects.Product ToDto(this Models.Product product)
        {
            if (product == null)
            {
                return null;
            }

            var dto = new DataTransferObjects.Product();

            dto.Id = product.Id;
            dto.Name = product.Name;
            dto.Ratings = product.Ratings.Select(r => r.ToDto());

            dto.Brand = product.Brand.ToDto();
            dto.Type = product.Type.ToDto();

            return dto;
        }

        public static Models.Product ToModel(this DataTransferObjects.Product product, DataAccess.Repository repository)
        {
            if (product == null)
            {
                return null;
            }

            var model = new Models.Product();
            model.Id = Guid.NewGuid();
            if (product.Id != new Guid())
            {
                model = repository.Products.Where(b => b.Id == product.Id).Single();
            }

            model.Name = product.Name;

            model.Brand = product.Brand.ToModel(repository);
            model.BrandId = model.Brand.Id;
            model.Type = product.Type.ToModel(repository);
            model.ProductTypeId = model.Type.Id;

            if (product.Ratings != null)
            {
                model.Ratings = product.Ratings.Select(r => r.ToModel(repository)).ToList();
            }

            return model;
        }
    }
}
