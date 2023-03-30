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
        public string Name { get; set; } = null!;
        public Guid TeamStatId { get; set; }
        public virtual TeamStatistic TeamStatistic { get; set; } = null!;
        public virtual ICollection<Player>? Players { get; set; }
    }
}
