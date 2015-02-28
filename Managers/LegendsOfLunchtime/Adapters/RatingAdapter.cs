using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfLunchtime.Managers.Adapters
{
    public static class RatingAdapter
    {
        public static DataTransferObjects.Rating ToDto(this Models.Rating rating)
        {
            if (rating == null)
            {
                return null;
            }

            var dto = new DataTransferObjects.Rating();

            dto.Id = rating.Id;
            dto.Value = rating.Value;

            dto.Type = rating.Type.ToDto();

            return dto;
        }

        public static Models.Rating ToModel(this DataTransferObjects.Rating rating, DataAccess.Repository repository)
        {
            if (rating == null)
            {
                return null;
            }
            var model = new Models.Rating();
            model.Id = Guid.NewGuid();
            if (rating.Id != new Guid())
            {
                model = repository.Ratings.Where(b => b.Id == rating.Id).Single();
            }

            model.Value = rating.Value;
            model.Type = rating.Type.ToModel(repository);
            model.RatingTypeId = model.Type.Id;

            return model;
        }
    }
}
