using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorReaper.Managers.Adapters;
using Imaginarium.DataAccess.Extensions;

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

        public IEnumerable<DataTransferObjects.AndroidReport> GetAll(string sort, int skip, int take)
        {
            if (take <= 0)
            {
                take = 10;
            }

            return new DataAccess.Repository().AndroidReports
                                            .Sort(sort)
                                            .Skip(skip)
                                            .Take(take)
                                            .ToList()
                                            .Select(m => m.ToDto());
        }
    }
}
