using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.LegendsOfLunchtime
{
    public class ReviewManager
    {
        public DataTransferObjects.LegendsOfLunchtime.Review Create(DataTransferObjects.LegendsOfLunchtime.Review review, string username)
        {
            var repo = new DataAccess.LegendsOfLunchtime.Repository();

            var reviewModel = new Adapters.LegendsOfLunchtime.ReviewAdapter().AdaptDto(review);
            reviewModel.Timestamp = DateTime.UtcNow;
            reviewModel.Author = repo.Users.Single(u => u.Username == username);
            repo.Reviews.Add(reviewModel);
            repo.SaveChanges();

            review.Id = repo.Reviews.Single(r => r.Slug == review.Slug).Id;

            return review;
        }

        public IEnumerable<DataTransferObjects.LegendsOfLunchtime.Review> GetAll()
        {
            var repo = new DataAccess.LegendsOfLunchtime.Repository();

            var reviews = repo.Reviews.ToList();

            return reviews.Select(r => new Adapters.LegendsOfLunchtime.ReviewAdapter().AdaptModel(r));
        }

        public DataTransferObjects.LegendsOfLunchtime.Review GetBySlug(string slug)
        {
            var repo = new DataAccess.LegendsOfLunchtime.Repository();

            var reviews = repo.Reviews.ToList();

            return new Adapters.LegendsOfLunchtime.ReviewAdapter().AdaptModel(reviews.Single(r => r.Slug == slug));
        }
    }
}
