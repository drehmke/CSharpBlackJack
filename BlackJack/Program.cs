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

            // Text strings ...

            // End text strings ...

            Utility myUtils = new Utility();
                
            // Instance of Deck
            Deck deck = new Deck();
            // Instantiate the two participants
            Dealer dealer = new Dealer();
            Player player = new Player();

            bool gameOver = false;

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


            // Time to play -- player first
            if ( myUtils.checkBlackJack(player.Hand) )
            {
                myUtils.ColorPrint("Congratulations! You have a Blackjack!", player.color);
                dealer.win = true;
                gameOver = true;
            } else
            {
                player.turn = true;
            }
            if( myUtils.checkBlackJack(dealer.Hand) )
            {
                myUtils.ColorPrint("I'm sorry, the house wins with a Blackjack.", dealer.color);
                gameOver = true;
            } else { player.turn = true; }

            if(!gameOver && player.turn == true)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("--- Player's  Turn ---");
                Console.WriteLine("----------------------");
                Console.WriteLine("Player, your total is currently: {0}", player.handTotal);
            }
            //Console.WriteLine("Player's turn status: {0}", player.turn);
            while (!gameOver && player.turn == true )
            {
                if ( player.handTotal < 21 )
                {
                    Console.WriteLine("What would you like to do?");
                    string playerMove = Console.ReadLine();
                    playerMove.Trim().ToLower();

                    switch (playerMove)
                    {
                        case "h":
                        case "hit":
                            Card newCard = dealer.DealCard(deck);
                            player.Hand.Add(newCard);
                            player.HandTotal();
                            myUtils.ColorPrint(String.Format("You chose to hit. You received a {0} of {1}. Your new total is {2}.", newCard.Rank, newCard.Suit, player.handTotal), player.color);
                            break;
                        case "s":
                        case "stay":
                            Console.WriteLine("You chose to stay. Your turn is now complete. It is now the dealer's turn.");
                            player.turn = false;
                            dealer.turn = true;
                            break;
                        default:
                            Console.WriteLine("I don't recognize that request. Please select either 'hit' or 'stay'.");
                            break;
                    }
                } else if (player.handTotal == 21 )
                {
                    myUtils.ColorPrint("You have 21!", player.color);
                    player.turn = false;
                    player.win = true;
                    
                } else
                {
                    myUtils.ColorPrint("You have bust.", "red");
                    dealer.win = true;
                    gameOver = true;
                }
            }

            // now the dealer
            if( dealer.turn == true && !gameOver )
            {
                dealer.PlayTurn(deck);
            }
            // real quick check if the dealer didn't win
            if( !dealer.win)
            {
                if( dealer.handTotal > 21 ) { player.win = true;  }
            }
            
            if (player.win == true)
            {
                myUtils.ColorPrint("-- Congratulations! You won! --", player.color);
                gameOver = true;
            }
            else if (dealer.win == true)
            {
                myUtils.ColorPrint("-- I am sorry. The house wins this round --.", dealer.color);
            } else
            {
                // no obvious winner, we need to evaluate ...
                if( player.handTotal > dealer.handTotal)
                {

                    Console.WriteLine("Player total is : {0} -- Dealer total is : {1}: ", player.handTotal, dealer.handTotal);
                    myUtils.ColorPrint("Congratulations! You won!", player.color);
                } else if( player.handTotal < dealer.handTotal )
                {

                    Console.WriteLine("Player total is : {0} -- Dealer total is : {1}: ", player.handTotal, dealer.handTotal);
                    myUtils.ColorPrint("-- I am sorry. The house wins this round. --", dealer.color);
                } else
                {
                    Console.WriteLine("-- The game was a draw. --");
                }
            }
            Console.ReadLine();
            
        }
    }

}