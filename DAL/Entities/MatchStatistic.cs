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
        public string WinType { get; set; } = null!;
        public virtual ICollection<Goal>? Goals { get; set; }
        public int Shots { get; set; }
        public int BlockedShots { get; set; }
        public virtual ICollection<Penalty>?  Penalties { get; set; }
    }
}
