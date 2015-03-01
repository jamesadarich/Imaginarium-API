using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegendsOfLunchtime.Api
{
    public class RatingTypeController : ApiController
    {
        [HttpGet]
        [Route("legends-of-lunchtime/rating-types")]
        public IEnumerable<DataTransferObjects.RatingType> GetAll()
        {
            return new Managers.RatingTypeManager().GetAll();
        }

        [HttpPost]
        [Route("legends-of-lunchtime/rating-type")]
        [Authorize]
        public DataTransferObjects.RatingType Post(DataTransferObjects.RatingType ratingType)
        {
            return new Managers.RatingTypeManager().Create(ratingType);
        }

        [HttpPut]
        [Route("legends-of-lunchtime/rating-type")]
        [Authorize]
        public DataTransferObjects.RatingType Put(DataTransferObjects.RatingType ratingType)
        {
            return new Managers.RatingTypeManager().Update(ratingType);
        }

        [HttpDelete]
        [Route("legends-of-lunchtime/rating-type/{id}")]
        [Authorize]
        public void Delete(Guid id)
        {
            new Managers.RatingTypeManager().Delete(id);
        }
    }
}
