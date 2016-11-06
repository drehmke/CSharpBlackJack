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
            string txtPlayerBorder = "---- Player ----";
            string txtDealerBorder = "---- Dealer ----";
            string txtHandTotal = "Hand total is currently:";
            string txtEndGame = "\nPress ENTER to end this game.";
            string txtPlayerCurrTotal = "Player, your total is currently: ";
            string txtPlayerTotal = "Player total is : ";
            string txtDealerTotal = "Dealer total is : ";
            string txtPlayerBlackJack = "Congratulations! You have a Blackjack!" + txtEndGame;
            string txtDealerBlackJack = "I'm sorry, the house wins with a Blackjack." + txtEndGame;
            string txtDealerWins = "-- I am sorry. The house wins this round --" + txtEndGame;
            string txtPlayerWins = "-- Congratulations! You won! --" + txtEndGame;
            string txtDraw = "-- The game was a draw. --" + txtEndGame;
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
            myUtils.ColorPrint(txtPlayerBorder, player.color);
            foreach (Card card in player.Hand)
            {
                Console.WriteLine("{0} of {1}", card.Rank, card.Suit);
            }
            player.HandTotal();
            myUtils.ColorPrint(String.Format("{0} {1}", txtHandTotal, player.handTotal), player.color);

            myUtils.ColorPrint(txtDealerBorder, dealer.color);
            foreach (Card card in dealer.Hand)
            {
                Console.WriteLine("{0} of {1}", card.Rank, card.Suit);
            }
            dealer.HandTotal();
            myUtils.ColorPrint(String.Format("{0} {1}", txtHandTotal, dealer.handTotal), dealer.color);


            // Time to play -- player first
            if ( myUtils.checkBlackJack(player.Hand) )
            {
                myUtils.ColorPrint(txtPlayerBlackJack, player.color);
                dealer.win = true;
                gameOver = true;
            } else
            {
                player.turn = true;
            }
            if( myUtils.checkBlackJack(dealer.Hand) )
            {
                myUtils.ColorPrint(txtDealerBlackJack, dealer.color);
                gameOver = true;
            } else { player.turn = true; }

            if(!gameOver && player.turn == true)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("--- Player's  Turn ---");
                Console.WriteLine("----------------------");
                Console.WriteLine("{0}{1}", txtPlayerCurrTotal, player.handTotal);
            }
            //Console.WriteLine("Player's turn status: {0}", player.turn);
            while (!gameOver && player.turn == true )
            {
                if ( player.handTotal < 21 )
                {
                    Console.WriteLine("What would you like to do?\n(Type \"hit\" or \"h\" to hit, \"stay\" or \"s\" to stay.)");
                    string playerMove = Console.ReadLine();
                    playerMove.Trim().ToLower();

                    switch (playerMove)
                    {

                        case "h":
                        case "hit":
                            Card newCard = dealer.DealCard(deck);
                            if( newCard.Rank == "Ace")
                            {
                                Console.WriteLine("You have received an Ace. Would you like it to be worth 1 or 11 ?");
                                newCard.Value = Convert.ToInt32(Console.ReadLine());
                            }
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
                    player.turn = false;
                    player.win = true;
                    
                } else
                {
                    myUtils.ColorPrint("You have bust.", "red");
                    dealer.win = true;
                    gameOver = true;
                    Console.WriteLine(txtEndGame);
                }
            }

            // now the dealer
            if( dealer.turn == true && !gameOver )
            {
                dealer.PlayTurn(deck);
            }
            // real quick check if the dealer didn't win
            if( !dealer.win && !gameOver)
            {
                if( dealer.handTotal > 21 ) { player.win = true;  }
            }
            
            if (player.win == true && !gameOver)
            {
                myUtils.ColorPrint(txtPlayerWins, player.color);
                gameOver = true;
            }
            else if (dealer.win == true && !gameOver )
            {
                myUtils.ColorPrint(txtDealerWins, dealer.color);
            } else if( !gameOver )
            {
                // no obvious winner, we need to evaluate ...
                if( player.handTotal > dealer.handTotal)
                {

                    Console.WriteLine("{0}{1} - {2}{3}", txtPlayerTotal, player.handTotal, txtDealerTotal, dealer.handTotal);
                    myUtils.ColorPrint(txtPlayerWins, player.color);
                } else if( player.handTotal < dealer.handTotal )
                {

                    Console.WriteLine("{0}{1} -- {2}{3}", txtPlayerTotal, player.handTotal, txtDealerTotal, dealer.handTotal);
                    myUtils.ColorPrint(txtDealerWins, dealer.color);
                } else
                {
                    Console.WriteLine(txtDraw);
                }
            }
            Console.ReadLine();
            
        }
    }

}