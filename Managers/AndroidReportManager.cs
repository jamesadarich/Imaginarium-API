using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class AndroidReportManager
    {
        public DataTransferObjects.AndroidReport Update(DataTransferObjects.AndroidReport report)
        {
            var model = new Adapters.AndroidReportAdapter().AdaptDto(report);

            new DataAccess.Repository().AndroidReports.Add(model);

            return report;
        }

        public IEnumerable<DataTransferObjects.AndroidReport> GetAll()
        {
            var models = new DataAccess.Repository().AndroidReports;

            return models.Select(m => new Adapters.AndroidReportAdapter().AdaptModel(m));
        }
    }
}
