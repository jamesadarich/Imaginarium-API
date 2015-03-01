using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegendsOfLunchtime.Api
{
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("legends-of-lunchtime/products")]
        public IEnumerable<DataTransferObjects.Product> GetAll()
        {
            return new Managers.ProductManager().GetAll();
        }

        [HttpPost]
        [Route("legends-of-lunchtime/product")]
        [Authorize]
        public DataTransferObjects.Product Post(DataTransferObjects.Product product)
        {
            return new Managers.ProductManager().Create(product);
        }

        [HttpPut]
        [Route("legends-of-lunchtime/product")]
        [Authorize]
        public DataTransferObjects.Product Put(DataTransferObjects.Product product)
        {
            return new Managers.ProductManager().Update(product);
        }

        [HttpDelete]
        [Route("legends-of-lunchtime/product")]
        [Authorize]
        public void Delete(DataTransferObjects.Product product)
        {
            new Managers.ProductManager().Delete(product);
        }
    }
}
