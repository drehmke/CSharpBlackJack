using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Classes
{
    class Dealer : Player
    {
        Utility myUtils = new Utility();
        
        public Card DealCard(Deck deck)
        {
            return deck.GetRandomCard();
        }

        public void PlayTurn(Deck deck)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("--- Dealer's  Turn ---");
            Console.WriteLine("----------------------");
            Console.WriteLine("Checking the dealer's hand ...");
            while (this.handTotal <= 16 )
            {
                Console.WriteLine("Dealer is taking another card ...");
                Card dealerCard = this.DealCard(deck);
                Console.WriteLine("Dealer received {0} of {1}", dealerCard.Rank, dealerCard.Suit);
                this.Hand.Add(dealerCard);
                this.HandTotal();
                myUtils.ColorPrint(String.Format("Dealer's hand is now {0}", this.handTotal), this.color);
            }
            if( this.handTotal >= 17 )
            {
                this.turn = false;
                if( this.handTotal > 21 )
                {
                    myUtils.ColorPrint("Dealer is bust!", "red");
                }
                else if( this.handTotal == 21 )
                {
                    myUtils.ColorPrint("Dealer has 21!", this.color);
                    this.win = true;
                }
                else
                { Console.WriteLine("Dealer is staying."); }
                
            }
        }

        public Dealer()
        {
            this.Hand = new List<Card>();
            this.color = "cyan";
        }
    }
}
