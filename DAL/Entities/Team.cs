using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Team
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; } = null!;
        public virtual TeamStatistic TeamStatistic { get; set; } = null!;
        public virtual ICollection<Player>? Players { get; set; }
    }
}
