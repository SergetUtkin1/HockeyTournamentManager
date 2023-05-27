namespace DAL.Entities
{
    public class Team
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; } = null!;
        public virtual TeamStatistic? TeamStatistic { get; set; }
        public virtual ICollection<Player>? Players { get; set; }
    }
}
