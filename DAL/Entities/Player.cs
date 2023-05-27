namespace DAL.Entities
{
    public class Player
    {
        public Guid PlayerId { get; set; }
        public Guid? TeamId { get; set; }
        public virtual Team? Team { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Number { get; set; }
        public ICollection<Goal>? Goals { get; set; }
        public ICollection<Goal> ? Assists { get; set; }
    }
}
