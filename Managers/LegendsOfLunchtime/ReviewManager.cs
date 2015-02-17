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

            var user = repo.Users.Single(u => u.Username == username);

            review.Author = new Adapters.LegendsOfLunchtime.UserAdapter().AdaptModel(user);

            var reviewModel = new Adapters.LegendsOfLunchtime.ReviewAdapter().AdaptDto(review);

            repo.Reviews.Add(reviewModel);

            review.Id = repo.Reviews.Single(r => r.Slug == review.Slug).Id;

            return review;
        }
    }
}
