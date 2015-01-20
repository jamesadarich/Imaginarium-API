using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataTransferObjects
{
    [DataContract]
    public class AndroidReport
    {
        [DataMember]
        public string STACK_TRACE;

        [DataMember]
        public DateTime USER_APP_START_DATE;

        [DataMember]
        public DateTime USER_CRASH_DATE;
    }
}
