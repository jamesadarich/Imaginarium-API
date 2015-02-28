using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LegendsOfLunchtime.Models
{
    public class ProductType
    {
        public ProductType()
        {
            RatingTypes = new List<RatingType>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RatingType> RatingTypes { get; set; }
    }
}
