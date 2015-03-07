using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Imaginarium.API.P

namespace ErrorReaper.API
{
    public class DotNetReportController : ApiController
    {
        [HttpGet]
        [Route("error-reaper/reports/dot-net")]
        public IEnumerable<DataTransferObjects.DotNetReport> Get()
        {
            var manager = new Managers.DotNetReportManager();
            return manager.GetAll();
        }

        [HttpGet]
        [Route("error-reaper/report/dot-net/{id}")]
        public DataTransferObjects.DotNetReport Get(Guid id)
        {
            var manager = new Managers.DotNetReportManager();
            return manager.GetById(id);
        }

        [HttpPost]
        [Route("error-reaper/report/dot-net")]
        public DataTransferObjects.DotNetReport Get(DataTransferObjects.DotNetReport report)
        {
            var manager = new Managers.DotNetReportManager();
            return manager.Create(report);
        }
    }
}
