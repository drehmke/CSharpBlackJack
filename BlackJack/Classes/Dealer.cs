using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Classes
{
    class Dealer : Player
    {
        //public List<Card> Hand { get; set; }
        
        public Card DealCard(Deck deck)
        {
            return deck.GetRandomCard();
        }
        public Dealer()
        {
            this.Hand = new List<Card>();
        }
    }
}
