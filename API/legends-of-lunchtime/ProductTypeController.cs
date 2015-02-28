using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Filters;

namespace LegendsOfLunchtime.Api
{
    public class ProductTypeController : ApiController
    {
        [HttpGet]
        [Route("legends-of-lunchtime/product-types")]
        [UnhandledExceptionFilter]
        public IEnumerable<DataTransferObjects.ProductType> GetAll()
        {
            return new Managers.ProductTypeManager().GetAll();
        }
    }
}
