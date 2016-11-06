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
        public int handTotal = 0;
        public bool turn = false;
        public bool win = false;
        public string color;

        public void HandTotal()
        {
            int tmpTotal = 0;
            foreach( Card card in this.Hand )
            {
                tmpTotal = tmpTotal + card.Value;
            }
            this.handTotal = tmpTotal;
        }

        public Player()
        {
            this.Hand = new List<Card>();
            this.color = "yellow";
        }
    }
}
