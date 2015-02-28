using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegendsOfLunchtime.Models
{
    public class Product
    {
        public Product()
        {
            Ratings = new List<Rating>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ProductTypeId { get; set; }
        public virtual ProductType Type { get; set; }

        public Guid BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
