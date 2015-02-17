using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.LegendsOfLunchtime
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        public Product Product { get; set; }

        public IEnumerable<Rating> Ratings { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

        public DateTime Timestamp { get; set; }

        public User Author { get; set; }
    }
}
