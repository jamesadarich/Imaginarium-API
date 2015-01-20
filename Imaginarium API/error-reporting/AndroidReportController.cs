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
        private static ICollection<DataTransferObjects.AndroidReport> reports;

        [HttpGet]
        [Route("error-reporting/reports/android")]
        public IEnumerable<DataTransferObjects.AndroidReport> Get()
        {
            if (reports == null)
            {
                reports = new List<DataTransferObjects.AndroidReport>();
            }

            return reports.AsEnumerable();
        }

        [HttpPut]
        [Route("error-reporting/report/android")]
        public DataTransferObjects.AndroidReport Put([FromBody] DataTransferObjects.AndroidReport report)
        {
            if (reports == null)
            {
                reports = new List<DataTransferObjects.AndroidReport>();
            }

            reports.Add(report);

            return report;

        }
    }
}
