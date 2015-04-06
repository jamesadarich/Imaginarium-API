using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TeamBuilder.DataTransferObjects
{
    [DataContract]
    public class Match
    {
        [DataMember]
        public Guid Id;

        [DataMember]
        public DateTime Timestamp;

        [DataMember]
        public IEnumerable<Team> Teams;
    }
}
