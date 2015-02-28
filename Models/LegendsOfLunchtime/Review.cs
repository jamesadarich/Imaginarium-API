using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegendsOfLunchtime.Models
{
    public class Review
    {
        public Review()
        {
            Ratings = new List<Rating>();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

        public DateTime Timestamp { get; set; }

        public Guid AuthorId { get; set; }
        public virtual User Author { get; set; }
    }
}
