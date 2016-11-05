using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Classes
{
    class Player
    {
        public List<Card> Hand { get; set; }

        public Player()
        {
            this.Hand = new List<Card>();
        }
    }
}
