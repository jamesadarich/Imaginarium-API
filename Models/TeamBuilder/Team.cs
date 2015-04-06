using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public class Team
    {
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

        private double _score;
        public double Score
        {
            get
            {
                return _score;
            }

            set
            {
                _score = value;
            }
        }

        private Guid _squadId;
        public Guid SquadId
        {
            get
            {
                return _squadId;
            }

            set
            {
                _squadId = value;
            }
        }

        public virtual Squad Squad { get; set; }
    }
}
