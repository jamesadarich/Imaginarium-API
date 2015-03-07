using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorReaper.Managers.Adapters
{
    public static class ApplicationAdapter
    {
        public static DataTransferObjects.Application ToDto(this Models.Application modelApplication)
        {
            if (modelApplication == null)
            {
                return null;
            }

            var dtoApplication = new DataTransferObjects.Application();

            dtoApplication.Id = modelApplication.Id;
            dtoApplication.Name = modelApplication.Name;

            return dtoApplication;
        }

        public static Models.Application ToModel(this DataTransferObjects.Application dtoApplication, DataAccess.Repository repository)
        {
            if (dtoApplication == null)
            {
                return null;
            }

            if (dtoApplication.Id != new Guid())
            {
                return repository.Applications.Single(a => a.Id == dtoApplication.Id);
            }

            var modelApplication = new Models.Application();

            modelApplication.Name = dtoApplication.Name;

            return modelApplication;
        }
    }
}
