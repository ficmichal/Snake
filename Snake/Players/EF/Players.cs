using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Players.EF
{
    public class SnakePlayers : DbContext
    {
        public SnakePlayers() : base("name=SnakeConnection")
        {
                
        }

        public virtual DbSet<Player> _Players { get; set; }
    }
}
