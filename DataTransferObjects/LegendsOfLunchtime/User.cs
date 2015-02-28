using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LegendsOfLunchtime.DataTransferObjects
{
    [DataContract]
    public class User
    {
        [DataMember]
        public Guid Id;

        [DataMember]
        public string Username;

        [DataMember]
        public string FirstName;

        [DataMember]
        public string LastName;

        [DataMember]
        public string ImageUrl;
    }
}
