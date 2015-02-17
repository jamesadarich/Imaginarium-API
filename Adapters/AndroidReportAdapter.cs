using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapters
{
    public class AndroidReportAdapter
    {
        public DataTransferObjects.AndroidReport AdaptModel(Models.AndroidReport model)
        {
            var dto = new DataTransferObjects.AndroidReport();

            dto.REPORT_ID = model.Id;
            dto.PACKAGE_NAME = model.PackageName;
            dto.STACK_TRACE = model.StackTrace;
            dto.LOG_CAT = model.LogCat;
            dto.USER_CRASH_DATE = model.CrashDate;

            return dto;
        }

        public Models.AndroidReport AdaptDto(DataTransferObjects.AndroidReport dto)
        {
            var model = new Models.AndroidReport(dto.REPORT_ID, dto.PACKAGE_NAME);

            model.StackTrace = dto.STACK_TRACE;
            model.LogCat = dto.LOG_CAT;
            if (dto.USER_CRASH_DATE.HasValue)
            {
                model.CrashDate = dto.USER_CRASH_DATE.Value;
            }

            if (string.IsNullOrWhiteSpace(model.StackTrace))
            {
                model.StackTrace = "Unknown";
            }
            if (string.IsNullOrWhiteSpace(model.LogCat))
            {
                model.LogCat = "Unknown";
            }
            if (model.CrashDate == new DateTime())
            {
                model.CrashDate = DateTime.UtcNow;
            }

            return model;
        }
    }
}
