using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.legends_of_lunchtime
{
    public class ProductTypeController : ApiController
    {
        [HttpGet]
        [Route("legends-of-lunchtime/product-types")]
        [Filters.UnhandledExceptionFilter]
        public IEnumerable<DataTransferObjects.LegendsOfLunchtime.ProductType> GetAll()
        {
            return new Managers.LegendsOfLunchtime.ProductTypeManager().GetAll();
        }
    }
}
