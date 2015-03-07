using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorReaper.Managers.Adapters
{
    public static class DotNetReportAdapter
    {
        public static DataTransferObjects.DotNetReport ToDto(this Models.DotNetReport modelReport)
        {
            if (modelReport == null)
            {
                return null;
            }

            var dtoReport = new DataTransferObjects.DotNetReport();

            dtoReport.Id = modelReport.Id;
            dtoReport.Timestamp = modelReport.Timestamp;

            dtoReport.Application = modelReport.Application.ToDto();

            dtoReport.Exception = modelReport.Exception.ToDto();

            return dtoReport;
        }

        public static Models.DotNetReport ToModel(this DataTransferObjects.DotNetReport dtoReport, DataAccess.Repository repository)
        {
            if (dtoReport == null)
            {
                return null;
            }

            if (dtoReport.Id != new Guid())
            {
                return repository.DotNetReports.Single(a => a.Id == dtoReport.Id);
            }

            var modelReport = new Models.DotNetReport();

            modelReport.Timestamp = dtoReport.Timestamp;

            modelReport.Application = dtoReport.Application.ToModel(repository);
            modelReport.ApplicationId = modelReport.Application.Id;

            modelReport.Exception = dtoReport.Exception.ToModel(repository);
            modelReport.ExceptionId = modelReport.Exception.Id;

            return modelReport;
        }
    }
}
