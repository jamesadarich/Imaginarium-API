using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public class Match
    {
        public Match()
        {
            Teams = new List<Team>();
        }

        private Guid _id;
        public Guid Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        private DateTime _timestamp;
        public DateTime Timestamp
        {
            get
            {
                return _timestamp;
            }

            set
            {
                _timestamp = value;
            }
        }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
