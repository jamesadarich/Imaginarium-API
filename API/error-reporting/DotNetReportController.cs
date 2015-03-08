using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ErrorReaper.Api
{
    public class DotNetReportController : ApiController
    {
        [HttpGet]
        [Route("error-reaper/reports/dot-net")]
        public IEnumerable<DataTransferObjects.DotNetReport> Get([FromUri] string sort = null,
                                                                 [FromUri] int skip = 0,
                                                                 [FromUri] int take = 10)
        {
            var manager = new Managers.DotNetReportManager();
            return manager.GetAll(sort, skip, take);
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
        [Filters.UnhandledExceptionFilter]
        public DataTransferObjects.DotNetReport Post(DataTransferObjects.DotNetReport report)
        {
            var manager = new Managers.DotNetReportManager();
            return manager.Create(report);
        }
    }
}
