using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    internal class Goal
    {
        public DateTime time { get; set; }
        public Player Author { get; set; } = null!;
        public Player? Asist1 { get; set; }
        public Player? Asist2 { get; set; }
        public bool IsEven { get; set; }
        public bool IsPowerPlay { get; set; }
        public bool IsShorthanded { get; set; }
    }
}
