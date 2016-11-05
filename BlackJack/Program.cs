using BlackJack.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instance of Deck
            Deck deck = new Deck();
            // Instantiate the two participants
            Dealer dealer = new Dealer();
            Player player = new Player();

            // Deal cards to players
            for( int i = 0; i < 2; i++)
            {
                Card playerCard = dealer.DealCard(deck);
                Card dealerCard = dealer.DealCard(deck);
                player.Hand.Add(playerCard);
                dealer.Hand.Add(dealerCard);
            }

            Console.WriteLine("---- Player ----");
            foreach(Card card in player.Hand)
            {
                Console.WriteLine("{0} of {1}", card.Rank, card.Suit);
            }
            Console.WriteLine("---- Dealer ----");
            foreach (Card card in dealer.Hand)
            {
                Console.WriteLine("{0} of {1}", card.Rank, card.Suit);
            }
            //Card cardFromDeck = dealer.DealCard(deck);


            // Check that the random card method works
            //Console.WriteLine("The random card you selected is the {0} of {1}", cardFromDeck.Rank, cardFromDeck.Suit);
            Console.WriteLine("----------------------");
            /*
            foreach( Card card in deck.Cards)
            {
                Console.WriteLine("{0} of {1}", card.Rank, card.Suit);
            }
            */
            Console.WriteLine("There are {0} cards left in the deck.", deck.Cards.Count);
            Console.ReadLine();
            
        }
    }

}
