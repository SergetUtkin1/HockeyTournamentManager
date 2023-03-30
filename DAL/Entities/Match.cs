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
        public virtual Team FirstTeam { get; set; } = null!;
        public virtual Team SecondTeam { get; set; } = null!;
        public virtual MatchStatistic StatOfFirstTeam { get; set; } = null!;
        public virtual MatchStatistic StatOfSecondTeam { get; set; } = null!;
        public DateTimeOffset Date { get; set; }
    }
}
