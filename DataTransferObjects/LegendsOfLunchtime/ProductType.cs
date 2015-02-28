using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LegendsOfLunchtime.DataTransferObjects
{
    [DataContract]
    public class ProductType
    {
        [DataMember]
        public Guid Id;

        [DataMember]
        public string Name;

        [DataMember]
        public IEnumerable<RatingType> RatingTypes;
    }
}
