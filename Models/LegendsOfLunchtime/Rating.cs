using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegendsOfLunchtime.Models
{
    public class Rating
    {
        [Key]
        public Guid Id { get; set; }

        public Guid RatingTypeId { get; set; }
        public virtual RatingType Type { get; set; }

        public Guid ReviewId { get; set; }
        public virtual Review Review { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Value { get; set; }
    }
}
