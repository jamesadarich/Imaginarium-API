﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataTransferObjects.LegendsOfLunchtime
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public Guid Id;

        [DataMember]
        public string Name;

        [DataMember]
        public ProductType Type;

        [DataMember]
        public Brand Brand;

        [DataMember]
        public IEnumerable<Rating> Ratings;
    }
}
