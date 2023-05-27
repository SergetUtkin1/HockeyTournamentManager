namespace DAL.Entities
{
    public class Match
    {
        public Guid MatchId { get; set; }
        public Guid FirstTeamId { get; set; }
        public Guid SecondTeamId { get; set; }
        public virtual Team FirstTeam { get; set; } = null!;
        public virtual Team SecondTeam { get; set; } = null!;
        public virtual MatchStatistic? FirstTeamStatistic { get; set; } = new MatchStatistic();
        public virtual MatchStatistic? SecondTeamStatistic { get; set; } = new MatchStatistic();
        public DateTime? Date { get; set; }
    }
}
