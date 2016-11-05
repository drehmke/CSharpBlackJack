using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Classes
{
    class Card
    {
        public int Id { get; set; }
        public string Suit { get; set; }
        public string Rank { get; set; }
        public int Value { get; set; }

        public Card(int id, string suit, int value, string rank)
        {
            this.Id = id;
            this.Suit = suit;
            this.Value = value;
            this.Rank = rank;
        }
    }
}
