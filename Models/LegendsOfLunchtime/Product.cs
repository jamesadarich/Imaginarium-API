using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.LegendsOfLunchtime
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ProductType Type { get; set; }

        public Brand Brand { get; set; }

        public IEnumerable<Rating> Ratings { get; set; }
    }
}
