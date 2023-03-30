using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    internal class MatchStatistic
    {
        public Guid StatId { get; set; }
        public virtual ICollection<Goal>? Goals { get; set; }
        public int ShotCount { get; set; }
        public int BlockedShots { get; set; }
        public virtual ICollection<Penalty>?  Penalties { get; set; }
    }
}
