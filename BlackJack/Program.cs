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
            for (int i = 0; i < 2; i++)
            {
                Card playerCard = dealer.DealCard(deck);
                Card dealerCard = dealer.DealCard(deck);
                player.Hand.Add(playerCard);
                dealer.Hand.Add(dealerCard);
            }
            
            // Set up the board
            Console.WriteLine("---- Player ----");
            foreach (Card card in player.Hand)
            {
                Console.WriteLine("{0} of {1}", card.Rank, card.Suit);
            }
            player.HandTotal();
            Console.WriteLine("Hand total is currently: {0}", player.handTotal);
            Console.WriteLine("---- Dealer ----");
            foreach (Card card in dealer.Hand)
            {
                Console.WriteLine("{0} of {1}", card.Rank, card.Suit);
            }
            dealer.HandTotal();
            Console.WriteLine("Hand total is currently: {0}", dealer.handTotal);

            Console.WriteLine("----------------------");

            // Time to play -- player first
            
            if( player.handTotal > 21 )
            {
                Console.WriteLine("You are now bust.");
                player.turn = false;
                dealer.turn = true;
            } else if( player.handTotal == 21 )
            {
                Console.WriteLine("You have 21!");
            } else 
            {
                player.turn = true;
            }
            
            //Console.WriteLine("Player's turn status: {0}", player.turn);
            while ( player.turn == true )
            {
                Console.WriteLine("What would you like to do?");
                string playerMove = Console.ReadLine();
                playerMove.Trim().ToLower();
                Console.WriteLine("You chose to {0} ... ", playerMove.Trim().ToLower());
                switch(playerMove)
                {
                    case "hit":
                        Card newCard = dealer.DealCard(deck);
                        player.Hand.Add(newCard);
                        Console.WriteLine("You received a {0} of {1}.", newCard.Rank, newCard.Suit);
                        player.HandTotal();
                        Console.WriteLine("Your new total is {0}", player.handTotal);
                        break;
                    case "stay":
                        Console.WriteLine("You chose {0}. Your turn is complete. The dealer will now go.", playerMove);
                        player.turn = false;
                        dealer.turn = true;
                        
                        break;
                    default:
                        Console.WriteLine("I don't recognize that request. Please select either 'hit' or 'stay'.");
                        break;
                }
            }

            // now the dealer
            switch(dealer.turn)
            {
                case true:
                    dealer.PlayTurn(deck);
                    break;
                case false:
                    break;
            }
            
            //Console.WriteLine("There are {0} cards left in the deck.", deck.Cards.Count);

            Console.ReadLine();
            
        }
    }

}