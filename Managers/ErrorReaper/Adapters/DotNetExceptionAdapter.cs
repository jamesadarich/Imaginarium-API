using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorReaper.Managers.Adapters
{
    public static class DotNetExceptionAdapter
    {
        public static DataTransferObjects.DotNetException ToDto(this Models.DotNetException modelException)
        {
            if (modelException == null)
            {
                return null;
            }

            var dtoException = new DataTransferObjects.DotNetException();

            dtoException.Id = modelException.Id;
            dtoException.Message = modelException.Message;
            dtoException.StackTrace = modelException.StackTrace;

            dtoException.InnerException = modelException.InnerException.ToDto();

            return dtoException;
        }

        public static Models.DotNetException ToModel(this DataTransferObjects.DotNetException dtoException, DataAccess.Repository repository)
        {
            if (dtoException == null)
            {
                return null;
            }

            if (dtoException.Id != new Guid())
            {
                return repository.DotNetExceptions.Single(a => a.Id == dtoException.Id);
            }

            var modelException = new Models.DotNetException();

            modelException.Id = Guid.NewGuid();
            modelException.Message = dtoException.Message;
            modelException.StackTrace = dtoException.StackTrace;

            modelException.InnerException = dtoException.InnerException.ToModel(repository);

            if (modelException.InnerException != null)
            {
                modelException.InnerExceptionId = modelException.InnerException.Id;
            }

            return modelException;
        }
    }
}
