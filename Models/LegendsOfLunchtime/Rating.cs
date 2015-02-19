using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.LegendsOfLunchtime
{
    public class Rating
    {
        [Key]
        public Guid Id { get; set; }

        public Guid RatingTypeId { get; set; }
        public virtual RatingType Type { get; set; }

        public int Value { get; set; }
    }
}
