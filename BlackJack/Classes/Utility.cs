using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Classes
{
    class Utility
    {
        public string SimpleCleanInput(string input)
        {
            return input.Trim().ToLower();
        }

        public void ColorPrint(string printable, string color)
        {
            switch(color)
            {
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.WriteLine(printable);
            Console.ResetColor();
        }

        public bool checkBlackJack(List<Card> hand)
        {
            bool hasAce = false;
            bool hasFace = false;

            foreach( Card card in hand )
            {
                if( card.Rank == "Ace")
                {
                    hasAce = true;
                }
                if( card.Rank == "Jack" || card.Rank == "Queen" || card.Rank == "King" )
                {
                    hasFace = true;
                }
            }

            if( hasFace == true && hasAce == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
