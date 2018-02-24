using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardGame
{
    class Card
    {
       public enum Color
        {
            CLUB = 0,
            SPADE,
            HEART,
            DIAMOND 
        }

        public enum Value
        {
            SEVEN = 7,
            EIGHT,
            NINE,
            TEN,
            JACK,
            QUEEN,
            KING,
            ACE
        }

        public Color     color { get; set; }
        public Value     value { get; set; }

        public Card (Color color, Value value)
        {
            this.color = color;
            this.value = value;
        }

    }
}