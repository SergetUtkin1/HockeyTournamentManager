using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    internal class Match
    {
        public Guid MatchId { get; set; }
        public Team FirstTeam { get; set; }
        public Team SecondTeam { get; set; }
        public MatchStatistic Stat { get; set; }
        public DateTimeOffset Date { get; set; }
}
}
