using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaderboard
{
    internal class Player
    {
        internal int lives;
        internal int score;
        internal string jmeno;
        public Player(string jmeno) 
        { 
            this.lives = 3;
            this.score = 0;
            this.jmeno = jmeno;
        }
    }
}
