using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfLunchtime.Managers.Adapters
{
    public static class BrandAdapter
    {
        public static DataTransferObjects.Brand ToDto(this Models.Brand brand)
        {
            if (brand == null)
            {
                return null;
            }

            var dto = new DataTransferObjects.Brand();

            dto.Id = brand.Id;
            dto.LogoUrl = brand.LogoUrl;
            dto.Name = brand.Name;

            return dto;
        }

        public static Models.Brand ToModel(this DataTransferObjects.Brand brand, DataAccess.Repository repository)
        {
            if (brand == null)
            {
                return null;
            }

            var model = new Models.Brand();
            model.Id = Guid.NewGuid();
            if (brand.Id != new Guid())
            {
                model = repository.Brands.Where(b => b.Id == brand.Id).Single();
            }

            model.LogoUrl = brand.LogoUrl;
            model.Name = brand.Name;

            return model;
        }
    }
}
