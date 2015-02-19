using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.LegendsOfLunchtime
{
    public class RatingTypeAdapter
    {
        public DataTransferObjects.LegendsOfLunchtime.RatingType AdaptModel(Models.LegendsOfLunchtime.RatingType ratingType)
        {
            if (ratingType == null)
            {
                return null;
            }

            var dto = new DataTransferObjects.LegendsOfLunchtime.RatingType();

            dto.Id = ratingType.Id;
            dto.IconUrl = ratingType.IconUrl;
            dto.Name = ratingType.Name;

            return dto;
        }

        public Models.LegendsOfLunchtime.RatingType AdaptDto(DataTransferObjects.LegendsOfLunchtime.RatingType ratingType)
        {
            if (ratingType == null)
            {
                return null;
            }

            var model = new Models.LegendsOfLunchtime.RatingType();

            model.Id = ratingType.Id;
            model.IconUrl = ratingType.IconUrl;
            model.Name = ratingType.Name;

            return model;
        }
    }
}
