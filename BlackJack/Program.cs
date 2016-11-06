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
            Utility myUtils = new Utility();
            
            // Instance of Deck
            Deck deck = new Deck();
            // Instantiate the two participants
            Dealer dealer = new Dealer();
            Player player = new Player();

            bool turnsDone = false;


            // Deal cards to players
            for (int i = 0; i < 2; i++)
            {
                Card playerCard = dealer.DealCard(deck);
                Card dealerCard = dealer.DealCard(deck);
                player.Hand.Add(playerCard);
                dealer.Hand.Add(dealerCard);
            }
            
            // Set up the board
            myUtils.ColorPrint("---- Player ----", player.color);
            foreach (Card card in player.Hand)
            {
                Console.WriteLine("{0} of {1}", card.Rank, card.Suit);
            }
            player.HandTotal();
            myUtils.ColorPrint(String.Format("Hand total is currently: {0}", player.handTotal), player.color);

            myUtils.ColorPrint("---- Dealer ----", dealer.color);
            foreach (Card card in dealer.Hand)
            {
                Console.WriteLine("{0} of {1}", card.Rank, card.Suit);
            }
            dealer.HandTotal();
            myUtils.ColorPrint(String.Format("Hand total is currently: {0}", dealer.handTotal), dealer.color);

            Console.WriteLine("----------------------");
            Console.WriteLine("--- Player's  Turn ---");
            Console.WriteLine("----------------------");
            Console.WriteLine("Player, your total is currently: {0}", player.handTotal);

            // Time to play -- player first
            if ( player.handTotal > 21 )
            {
                myUtils.ColorPrint("You are bust", "red");
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
                string tmp = String.Format("You chose to {0} ... ", myUtils.SimpleCleanInput(playerMove));
                //Console.WriteLine(sb);
                switch(playerMove)
                {
                    case "hit":
                        Card newCard = dealer.DealCard(deck);
                        player.Hand.Add(newCard);
                        player.HandTotal();
                        tmp += String.Format("You received a {0} of {1}. Your new total is {2}.", newCard.Rank, newCard.Suit, player.handTotal);
                        myUtils.ColorPrint(tmp, player.color);
                        break;
                    case "stay":
                        tmp += " Your turn is now complete. It is now the dealer's turn.";
                        Console.WriteLine(tmp);
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
                    turnsDone = true;
                    break;
            }
            

            Console.ReadLine();
            
        }
    }

}