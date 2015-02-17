using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.LegendsOfLunchtime
{
    public class ProductType
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<RatingType> RatingTypes { get; set; }
    }
}
