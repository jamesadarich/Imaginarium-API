using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorReaper.Managers.Adapters;

namespace ErrorReaper.Managers
{
    public class DotNetReportManager
    {
        public DataTransferObjects.DotNetReport GetById(Guid reportId)
        {
            var repository = new DataAccess.Repository();
            return repository.DotNetReports.Single(r => r.Id == reportId).ToDto();
        }

        public IEnumerable<DataTransferObjects.DotNetReport> GetAll(string sort, int take)
        {
            if (take <= 0)
            {
                take = 10;
            }

            var repository = new DataAccess.Repository();
            return repository.DotNetReports.OrderByDescending(x => x.Timestamp).Take(take).ToList().Select(r => r.ToDto());
        }

        public DataTransferObjects.DotNetReport Create(DataTransferObjects.DotNetReport report)
        {
            var repository = new DataAccess.Repository();
            var modelReport = report.ToModel(repository);
            repository.DotNetReports.Add(modelReport);
            repository.SaveChanges();
            return modelReport.ToDto();
        }

        public DataTransferObjects.DotNetReport Update(DataTransferObjects.DotNetReport report)
        {
            var repository = new DataAccess.Repository();
            var modelReport = report.ToModel(repository);
            repository.DotNetReports.Add(modelReport);
            repository.SaveChanges();
            return modelReport.ToDto();
        }

        public DataTransferObjects.DotNetReport Delete(DataTransferObjects.DotNetReport report)
        {
            var repository = new DataAccess.Repository();
            var modelReport = report.ToModel(repository);
            repository.DotNetReports.Remove(modelReport);
            repository.SaveChanges();
            return modelReport.ToDto();
        }
    }
}
