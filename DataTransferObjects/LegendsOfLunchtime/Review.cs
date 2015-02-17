using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataTransferObjects.LegendsOfLunchtime
{
    [DataContract]
    public class Review
    {
        [DataMember]
        public Guid Id;

        [DataMember]
        public Product Product;

        [DataMember]
        public IEnumerable<Rating> Ratings;

        [DataMember]
        public string Title;

        [DataMember]
        public string Slug;

        [DataMember]
        public string Summary;

        [DataMember]
        public string Content;

        [DataMember]
        public DateTime Timestamp;

        [DataMember]
        public User Author;
    }
}
