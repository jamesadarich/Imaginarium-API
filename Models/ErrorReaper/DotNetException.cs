using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorReaper.Models
{
    public class DotNetException
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public Nullable<Guid> InnerExceptionId { get; set; }
        public virtual DotNetException InnerException { get; set; }
    }
}
