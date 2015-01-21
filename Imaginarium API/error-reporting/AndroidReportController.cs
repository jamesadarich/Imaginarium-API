using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Imaginarium_API.error_reporting
{
    public class AndroidReportController : ApiController
    {
        [HttpGet]
        [Route("error-reporting/reports/android")]
        public IEnumerable<DataTransferObjects.AndroidReport> Get()
        {
            var manager = new Managers.AndroidReportManager();

            return manager.GetAll();
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
