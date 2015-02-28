using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendsOfLunchtime.Managers.Adapters;

namespace LegendsOfLunchtime.Managers
{
    public class ReviewManager
    {
        public DataTransferObjects.Review Create(DataTransferObjects.Review review, string username)
        {
            var repo = new DataAccess.Repository();

            review.Timestamp = DateTime.UtcNow;
            review.Author = repo.Users.Single(u => u.Username == username).ToDto();

            var reviewModel = review.ToModel(repo);
            var reviewRatings = reviewModel.Ratings.ToList();
            reviewRatings.ForEach(r =>
            {
                r.Product = reviewModel.Product;
                r.ProductId = reviewModel.ProductId;
                r.Review = reviewModel;
                r.ReviewId = reviewModel.Id;
            });

            reviewModel.Ratings = reviewRatings;

            repo.Reviews.Add(reviewModel);
            repo.SaveChanges();

            return reviewModel.ToDto();
        }

        public IEnumerable<DataTransferObjects.Review> GetAll()
        {
            var repo = new DataAccess.Repository();

            var reviews = repo.Reviews.ToList();

            return reviews.Select(r => r.ToDto());
        }

        public DataTransferObjects.Review GetBySlug(string slug)
        {
            var repo = new DataAccess.Repository();

            var reviews = repo.Reviews.ToList();

            return reviews.Single(r => r.Slug == slug).ToDto();
        }
    }
}
