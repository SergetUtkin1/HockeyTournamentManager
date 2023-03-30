using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    internal class TeamStatistic
    {
        public Guid TeamStatId { get; set; }
        public int Scores { get; set; } = 0;
        public int WinsAtRegularTime { get; set; } = 0;
        public int WinsAtOT { get; set; } = 0;
        public int WinsAtShootOut { get; set; } = 0;
    }
}
