using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LegendsOfLunchtime.Api
{
    public class BrandController : ApiController
    {
        [HttpGet]
        [Route("legends-of-lunchtime/brands")]
        public IEnumerable<DataTransferObjects.Brand> GetAll()
        {
            return new Managers.BrandManager().GetAll();
        }

        [HttpPost]
        [Route("legends-of-lunchtime/brand")]
        [Authorize]
        public DataTransferObjects.Brand Post(DataTransferObjects.Brand brand)
        {
            return new Managers.BrandManager().Create(brand);
        }

        [HttpPut]
        [Route("legends-of-lunchtime/brand")]
        [Authorize]
        public DataTransferObjects.Brand Put(DataTransferObjects.Brand brand)
        {
            return new Managers.BrandManager().Update(brand);
        }

        [HttpDelete]
        [Route("legends-of-lunchtime/brand/{id}")]
        [Authorize]
        public void Delete(Guid id)
        {
            new Managers.BrandManager().Delete(id);
        }
    }
}
