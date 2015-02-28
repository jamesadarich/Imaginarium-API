using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfLunchtime.Managers.Adapters
{
    public static class ReviewAdapter
    {
        public static DataTransferObjects.Review ToDto(this Models.Review review)
        {
            if (review == null)
            {
                return null;
            }

            var dto = new DataTransferObjects.Review();

            dto.Content = review.Content;
            dto.Id = review.Id;
            dto.Slug = review.Slug;
            dto.Summary = review.Summary;
            dto.Timestamp = review.Timestamp;
            dto.Title = review.Title;

            dto.Author = review.Author.ToDto();
            dto.Product = review.Product.ToDto();
            dto.Ratings = review.Ratings.Select(r => r.ToDto());

            return dto;
        }

        public static Models.Review ToModel(this DataTransferObjects.Review review, DataAccess.Repository repository)
        {
            if (review == null)
            {
                return null;
            }

            var model = new Models.Review();
            model.Id = Guid.NewGuid();
            if (review.Id != new Guid())
            {
                model = repository.Reviews.Where(b => b.Id == review.Id).Single();
            }

            model.Content = review.Content;
            model.Slug = review.Slug;
            model.Summary = review.Summary;
            model.Timestamp = review.Timestamp;
            model.Title = review.Title;

            model.Author = review.Author.ToModel(repository);
            model.AuthorId = model.Author.Id;
            model.Product = review.Product.ToModel(repository);
            model.ProductId = model.Product.Id;

            if (review.Ratings == null)
            {
                model.Ratings = null;
            }
            else
            {
                model.Ratings = review.Ratings.Select(r => r.ToModel(repository)).ToList();
            }

            return model;
        }
    }
}
