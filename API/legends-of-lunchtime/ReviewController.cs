using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegendsOfLunchtime.Api
{
    public class ReviewController : ApiController
    {
        [HttpGet]
        [Route("legends-of-lunchtime/reviews")]
        public IEnumerable<DataTransferObjects.Review> GetAll()
        {
            /*c
            var reviews = new List<DataTransferObjects.LegendsOfLunchtime.Review>();

            for (var i = 0; i < 5; i++)
            {
                var review = new DataTransferObjects.LegendsOfLunchtime.Review();
                review.Id = Guid.NewGuid();
                review.Content = string.Format("review {0} is a certain sort of thing.", i);

                var product = new DataTransferObjects.LegendsOfLunchtime.Product();
                product.Id = Guid.NewGuid();
                product.Name = string.Format("Product {0}", i);

                var brand = new DataTransferObjects.LegendsOfLunchtime.Brand();
                brand.Id = Guid.NewGuid();
                brand.Name = string.Format("Brand {0}", i);
                brand.LogoUrl = string.Format("Brand-{0}.png", i);
                product.Brand = brand;

                var productType = new DataTransferObjects.LegendsOfLunchtime.ProductType();
                productType.Id = Guid.NewGuid();
                productType.Name = string.Format("Product Type {0}", i);
                product.Type = productType;
                review.Product = product;

                review.Title = string.Format("A Review of {0}", product.Name);
                review.Slug = product.Name.Replace(" ", "_");
                review.Summary = string.Format("There's something about {0}...", product.Name);

                var ratings = new List<DataTransferObjects.LegendsOfLunchtime.Rating>();

                for (var j = 0; j < 3; j++)
                {
                    var rating = new DataTransferObjects.LegendsOfLunchtime.Rating();

                    rating.Id = Guid.NewGuid();
                    rating.Value = i * j;

                    var ratingType = new DataTransferObjects.LegendsOfLunchtime.RatingType();
                    ratingType.Id = Guid.NewGuid();
                    ratingType.Name = string.Format("Rating Type {0}", j);
                    ratingType.IconUrl = string.Format("Rating-Type-{0}.png", j);
                    rating.Type = ratingType;
                }
                review.Ratings = ratings.AsEnumerable();
            }

            return reviews;
             */

            return new Managers.ReviewManager().GetAll();
        }

        [HttpGet]
        [Route("legends-of-lunchtime/review/{slug}")]
        public DataTransferObjects.Review Get(string slug)
        {
            /*
            var review = new DataTransferObjects.LegendsOfLunchtime.Review();
            review.Id = Guid.NewGuid();
            review.Content = string.Format("review {0} is a certain sort of thing.", slug);
                
            var product = new DataTransferObjects.LegendsOfLunchtime.Product();
            product.Id = Guid.NewGuid();
            product.Name = string.Format("Product {0}", slug);

            var brand = new DataTransferObjects.LegendsOfLunchtime.Brand();
            brand.Id = Guid.NewGuid();
            brand.Name = string.Format("Brand {0}", slug);
            brand.LogoUrl = string.Format("Brand-{0}.png", slug);
            product.Brand = brand;

            var productType = new DataTransferObjects.LegendsOfLunchtime.ProductType();
            productType.Id = Guid.NewGuid();
            productType.Name = string.Format("Product Type {0}", slug);
            product.Type = productType;
            review.Product = product;

            review.Title = string.Format("A Review of {0}", product.Name);
            review.Slug = slug;
            review.Summary = string.Format("There's something about {0}...", product.Name);

            var ratings = new List<DataTransferObjects.LegendsOfLunchtime.Rating>();

            for (var j = 0; j < 3; j++){
                var rating = new DataTransferObjects.LegendsOfLunchtime.Rating();

                rating.Id = Guid.NewGuid();
                rating.Value = 2 * j;

                var ratingType = new DataTransferObjects.LegendsOfLunchtime.RatingType();
                ratingType.Id = Guid.NewGuid();
                ratingType.Name = string.Format("Rating Type {0}", j);
                ratingType.IconUrl = string.Format("Rating-Type-{0}.png", j);
                rating.Type = ratingType;
            }
            review.Ratings = ratings.AsEnumerable();

            return review;
             */

            return new Managers.ReviewManager().GetBySlug(slug);
        }

        [Authorize]
        [HttpPost]
        [Route("legends-of-lunchtime/review")]
        [ErrorReaper.Api.Filters.UnhandledExceptionFilter]
        public DataTransferObjects.Review Post([FromBody] DataTransferObjects.Review review)
        {
            var username = User.Identity.Name;
            //review.Id = Guid.NewGuid();

            review = new Managers.ReviewManager().Create(review, username);
            return review;
        }

        [HttpPut]
        [Route("legends-of-lunchtime/review")]
        [Authorize]
        public DataTransferObjects.Review Put([FromBody] DataTransferObjects.Review review)
        {
            return review;
        }
    }
}
