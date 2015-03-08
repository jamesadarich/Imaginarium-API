using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ErrorReaper.Api
{
    public class AndroidReportController : ApiController
    {
        [HttpGet]
        [Route("error-reporting/reports/android")]
        public IEnumerable<DataTransferObjects.AndroidReport> Get([FromUri] string sort, [FromUri] int take)
        {
            var manager = new Managers.AndroidReportManager();

            return manager.GetAll(sort, take);
        }

        [HttpPut]
        [Route("error-reporting/report/android/{id}")]
        public DataTransferObjects.AndroidReport Put(Guid id, [FromBody] DataTransferObjects.AndroidReport report)
        {
            var manager = new Managers.AndroidReportManager();

            return manager.Update(report);
        }
    }
}
