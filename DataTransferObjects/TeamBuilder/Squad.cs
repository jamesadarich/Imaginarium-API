using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TeamBuilder.DataTransferObjects
{
    [DataContract]
    public class Squad
    {
        [DataMember]
        public Guid Id;

        [DataMember]
        public string Name;

        [DataMember]
        public IEnumerable<Player> Players;
    }
}
