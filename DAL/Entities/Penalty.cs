using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Penalty
    {
        public Guid PenaltyId { get; set; }
        public virtual Infraction Infraction { get; set; } = null!;
        public int Minutes { get; set; }
        public virtual Player Player { get; set; } = null!;
    }
}
