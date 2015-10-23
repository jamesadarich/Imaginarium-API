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
            try
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
            catch (Exception e)
            {
                var dotNetReport = new DataTransferObjects.DotNetReport();
                dotNetReport.Application = new DataTransferObjects.Application();
                dotNetReport.Application.Name = "Android Report Manager";
                dotNetReport.Exception = new DataTransferObjects.DotNetException();
                dotNetReport.Exception.Message = e.Message;
                dotNetReport.Exception.StackTrace = e.StackTrace;
                dotNetReport.Timestamp = DateTime.UtcNow;
                var dotNetManager = new DotNetReportManager();
                dotNetManager.Create(dotNetReport);
                throw e;
            }
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
