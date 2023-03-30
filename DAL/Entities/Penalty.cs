using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    internal class Penalty
    {
        public Guid PenaltyId { get; set; }
        public virtual Infraction Infraction { get; set; }
        public int Minutes { get; set; }
        public virtual Player Player { get; set; }
    }
}
