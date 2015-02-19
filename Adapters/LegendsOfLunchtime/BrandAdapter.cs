using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.LegendsOfLunchtime
{
    public class BrandAdapter
    {
        public DataTransferObjects.LegendsOfLunchtime.Brand AdaptModel(Models.LegendsOfLunchtime.Brand brand)
        {
            if (brand == null)
            {
                return null;
            }

            var dto = new DataTransferObjects.LegendsOfLunchtime.Brand();

            dto.Id = brand.Id;
            dto.LogoUrl = brand.LogoUrl;
            dto.Name = brand.Name;

            return dto;
        }

        public Models.LegendsOfLunchtime.Brand AdaptModel(DataTransferObjects.LegendsOfLunchtime.Brand brand)
        {
            if (brand == null)
            {
                return null;
            }

            var model = new Models.LegendsOfLunchtime.Brand();

            model.Id = brand.Id;
            model.LogoUrl = brand.LogoUrl;
            model.Name = brand.Name;

            return model;
        }
    }
}
