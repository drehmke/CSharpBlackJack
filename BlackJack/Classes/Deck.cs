using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Classes
{
    class Deck
    {
        public List<Card> Cards { get; set; }
        public Random Randomizer { get; set; }
        
        public Card GetRandomCard()
        {
            Card cardToReturn = this.Cards[Randomizer.Next(0, this.Cards.Count)];
            this.Cards.Remove(cardToReturn);
            return cardToReturn;
        }

        public Deck()
        {
            // setup our card suits
            string[] suits = new string[] { "Spades", "Hearts", "Diamonds", "Clubs" };
            // setup our card ranks and values for those ranks
            Dictionary<string, int> cardRankValue = new Dictionary<string, int>();
            cardRankValue.Add("2", 2);
            cardRankValue.Add("3", 3);
            cardRankValue.Add("4", 4);
            cardRankValue.Add("5", 5);
            cardRankValue.Add("6", 6);
            cardRankValue.Add("7", 7);
            cardRankValue.Add("8", 8);
            cardRankValue.Add("9", 9);
            cardRankValue.Add("10", 10);
            cardRankValue.Add("Jack", 10);
            cardRankValue.Add("Queen", 10);
            cardRankValue.Add("King", 10);
            cardRankValue.Add("Ace", 11);
            // initialize our deck before we start shoving cards into it
            this.Cards = new List<Card>();
            // set our ID value
            int id = 0;
            foreach( string suit in suits)
            {
                foreach( KeyValuePair<string, int> rankAndValue in cardRankValue)
                {
                    this.Cards.Add(new Card(id, suit, rankAndValue.Value, rankAndValue.Key));
                    id++; // iterate the ID value
                }
            }

            // Instantiate a new instance of Random
            this.Randomizer = new Random();
        }
    }
}
