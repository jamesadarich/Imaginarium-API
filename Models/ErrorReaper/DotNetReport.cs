using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorReaper.Models
{
    public class DotNetReport
    {
        public Guid Id { get; set; }

        public DateTime Timestamp { get; set; }

        public Guid ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        public Guid ExceptionId { get; set; }
        public virtual DotNetException Exception { get; set; }
    }
}
