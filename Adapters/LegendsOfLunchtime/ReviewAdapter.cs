using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters.LegendsOfLunchtime
{
    public class ReviewAdapter
    {
        public Models.LegendsOfLunchtime.Review AdaptDto(DataTransferObjects.LegendsOfLunchtime.Review review)
        {
            if (review == null)
            {
                return null;
            }

            var model = new Models.LegendsOfLunchtime.Review();

            model.Content = review.Content;
            model.Id = review.Id;
            model.Slug = review.Slug;
            model.Summary = review.Summary;
            model.Timestamp = review.Timestamp;
            model.Title = review.Title;

            model.Author = new UserAdapter().AdaptDto(review.Author);
            model.Product = new ProductAdapter().AdaptDto(review.Product);
            model.Ratings = review.Ratings.Select(r => new RatingAdapter().AdaptDto(r)).ToList();

            return model;
        }

        public DataTransferObjects.LegendsOfLunchtime.Review AdaptModel(Models.LegendsOfLunchtime.Review review)
        {
            if (review == null)
            {
                return null;
            }

            var dto = new DataTransferObjects.LegendsOfLunchtime.Review(); var model = new Models.LegendsOfLunchtime.Review();

            dto.Content = review.Content;
            dto.Id = review.Id;
            dto.Slug = review.Slug;
            dto.Summary = review.Summary;
            dto.Timestamp = review.Timestamp;
            dto.Title = review.Title;

            dto.Author = new UserAdapter().AdaptModel(review.Author);
            dto.Product = new ProductAdapter().AdaptModel(review.Product);
            dto.Ratings = review.Ratings.Select(r => new RatingAdapter().AdaptModel(r));

            return dto;
        }
    }
}
