using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    internal class Goal
    {
        public Guid GoalId { get; set; }
        public virtual Match Match { get; set; } = null!;
        public DateTime Time { get; set; }
        public virtual Player Author { get; set; } = null!;
        public virtual Player? Asist1 { get; set; }
        public virtual Player? Asist2 { get; set; }
        public bool IsEven { get; set; }
        public bool IsPowerPlay { get; set; }
        public bool IsShorthanded { get; set; }
    }
}
