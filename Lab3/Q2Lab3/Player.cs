using System.Collections.Generic;
using System.Linq;

namespace Q2Lab3
{
    class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

        public static IQueryable<Player> GetPlayers()
        {
            return new List<Player>
            {
                new Player { FirstName = "Marcus", LastName = "Stroman", Position = "Pitcher" },
                new Player { FirstName = "Kevin", LastName = "Pillar", Position = "Center fielder" },
                new Player { FirstName = "Justin", LastName = "Smoak", Position = "First baseman" },
                new Player { FirstName = "Freddy", LastName = "Galvis", Position = "Shortstop" }
            }.AsQueryable<Player>();
        }
    }
}
