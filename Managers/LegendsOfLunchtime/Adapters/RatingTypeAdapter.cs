using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfLunchtime.Managers.Adapters
{
    public static class RatingTypeAdapter
    {
        public static DataTransferObjects.RatingType ToDto(this Models.RatingType ratingType)
        {
            if (ratingType == null)
            {
                return null;
            }

            var dto = new DataTransferObjects.RatingType();

            dto.Id = ratingType.Id;
            dto.IconUrl = ratingType.IconUrl;
            dto.Name = ratingType.Name;

            return dto;
        }

        public static Models.RatingType ToModel(this DataTransferObjects.RatingType ratingType, DataAccess.Repository repository)
        {
            if (ratingType == null)
            {
                return null;
            }

            var model = new Models.RatingType();
            model.Id = Guid.NewGuid();
            if (ratingType.Id != new Guid())
            {
                model = repository.RatingTypes.Where(b => b.Id == ratingType.Id).Single();
            }

            model.IconUrl = ratingType.IconUrl;
            if (model.IconUrl == null)
            {
                model.IconUrl = "default.svg";
            }
            model.Name = ratingType.Name;

            return model;
        }
    }
}
