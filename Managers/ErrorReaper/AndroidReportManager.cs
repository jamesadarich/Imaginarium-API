using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorReaper.Managers.Adapters;

namespace ErrorReaper.Managers
{
    public class AndroidReportManager
    {
        public DataTransferObjects.AndroidReport Update(DataTransferObjects.AndroidReport report)
        {
            var model = report.ToModel();

            var repository = new DataAccess.Repository();
            repository.AndroidReports.Add(model);
            repository.SaveChanges();

            return report;
        }

        public IEnumerable<DataTransferObjects.AndroidReport> GetAll(string sort, int take)
        {
            if (take <= 0)
            {
                take = 10;
            }

            var models = new DataAccess.Repository().AndroidReports.ToList();

            return models.OrderByDescending(x => x.CrashDate).Take(take).Select(m => m.ToDto());
        }
    }
}
