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
            var existingModel = repository.AndroidReports.SingleOrDefault(m => m.Id == model.Id);
            if (existingModel != null)
            {
                existingModel.LogCat = model.LogCat;
                existingModel.CrashDate = model.CrashDate;
                existingModel.PackageName = model.PackageName;
                existingModel.StackTrace = model.StackTrace;
                repository.Entry(existingModel).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                repository.AndroidReports.Add(model);
            }
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
