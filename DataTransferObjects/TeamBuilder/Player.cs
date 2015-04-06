using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TeamBuilder.DataTransferObjects
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public Guid Id;

        [DataMember]
        public string FirstName;

        [DataMember]
        public string LastName;

        [DataMember]
        public bool IsActive;
    }
}
