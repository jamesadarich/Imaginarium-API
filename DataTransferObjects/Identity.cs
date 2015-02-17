using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataTransferObjects
{
    [DataContract]
    public class Identity
    {
        [DataMember]
        public string Username;

        [DataMember]
        public string Password;
    }
}
