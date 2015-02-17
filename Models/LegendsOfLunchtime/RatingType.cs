using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.LegendsOfLunchtime
{
    public class RatingType
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string IconUrl { get; set; }
    }
}
