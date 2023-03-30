using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    internal class Team
    {
        public Guid TeamId { get; set; }
        public virtual ICollection<Player> Players { get; set; } = null!;

    }
}
