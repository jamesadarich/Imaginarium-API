using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Imaginarium_API.legends_of_lunchtime
{
    public class ReviewController : ApiController
    {
        [HttpGet]
        [Route("legends-of-lunchtime/reviews/{productTypeName}")]
        public IEnumerable<DataTransferObjects.LegendsOfLunchtime.Review> GetAll(string productTypeName)
        {
            var reviews = new List<DataTransferObjects.LegendsOfLunchtime.Review>();

            var review = new DataTransferObjects.LegendsOfLunchtime.Review();
            review.Id = Guid.NewGuid();

            var product = new DataTransferObjects.LegendsOfLunchtime.Product();
            product.Id = Guid.NewGuid();
            product.Name = "Test Product";

            var productType = new DataTransferObjects.LegendsOfLunchtime.ProductType();
            productType.Id = Guid.NewGuid();
            productType.Name = productTypeName;
            product.Type = productType;          


            review.Product = product;

            reviews.Add(review);
            reviews.Add(review);
            reviews.Add(review);
            reviews.Add(review);
            reviews.Add(review);
            reviews.Add(review);

            return reviews;
        }
    }
}
