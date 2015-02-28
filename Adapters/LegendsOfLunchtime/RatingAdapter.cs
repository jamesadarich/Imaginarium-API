using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.LegendsOfLunchtime
{
    public class RatingAdapter
    {
        public DataTransferObjects.LegendsOfLunchtime.Rating AdaptModel(Models.LegendsOfLunchtime.Rating rating)
        {
            if (rating == null)
            {
                return null;
            }

            var dto = new DataTransferObjects.LegendsOfLunchtime.Rating();

            dto.Id = rating.Id;
            dto.Value = rating.Value;

            dto.Type = new RatingTypeAdapter().AdaptModel(rating.Type);

            return dto;
        }

        public Models.LegendsOfLunchtime.Rating AdaptDto(DataTransferObjects.LegendsOfLunchtime.Rating rating)
        {
            if (rating == null)
            {
                return null;
            }
            var model = new Models.LegendsOfLunchtime.Rating();
            model.Id = Guid.NewGuid();
            if (rating.Id != new Guid())
            {
                model = new DataAccess.LegendsOfLunchtime.Repository().Ratings.Where(b => b.Id == rating.Id).Single();
            }

            model.Value = rating.Value;
            model.Type = new RatingTypeAdapter().AdaptDto(rating.Type);
            model.RatingTypeId = model.Type.Id;

            return model;
        }
    }
}
