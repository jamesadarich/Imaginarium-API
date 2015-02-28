using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LegendsOfLunchtime.DataTransferObjects
{
    [DataContract]
    public class Rating
    {
        [DataMember]
        public Guid Id;

        [DataMember]
        public RatingType Type;

        [DataMember]
        public int Value;
    }
}
