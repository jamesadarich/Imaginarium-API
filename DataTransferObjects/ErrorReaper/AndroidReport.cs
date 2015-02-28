using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ErrorReaper.DataTransferObjects
{
    [DataContract]
    public class AndroidReport
    {
        [DataMember]
        public Guid REPORT_ID;

        [DataMember]
        public string PACKAGE_NAME;

        [DataMember]
        public string STACK_TRACE;

        [DataMember]
        public string LOG_CAT;

        [DataMember]
        public Nullable<DateTime> USER_APP_START_DATE;

        [DataMember]
        public Nullable<DateTime> USER_CRASH_DATE;
    }
}
