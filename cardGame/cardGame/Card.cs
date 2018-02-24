using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardGame
{
    class Card
    {
       enum Color
        {
            CLUB = 0,
            SPADE,
            HEART,
            DIAMOND 
        }

        enum Value
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

        private Color    color;
        private Value    value;

        public Card (Color color, Value value)
        {
            this.color = color;
            this.value = value;
        }
        public Color getColor()
        {
            return color;
        }

        public Value getValue()
        {
            return value;
        }

    }
}