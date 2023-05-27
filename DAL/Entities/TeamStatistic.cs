namespace DAL.Entities
{
    public class TeamStatistic
    {
        public Guid TeamStatisticId { get; set; }
        public int Scores { get; set; } = 0;
        public int WinsAtRegularTime { get; set; } = 0;
        public int WinsAtOT { get; set; } = 0;
        public int WinsAtShootOut { get; set; } = 0;
    }
}
