﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardGame
{
    class Hand
    {
        List<Card> cards { get; set; }

        public Hand(List<Card> cards)
        {
            this.cards = cards;
        }

        public List<Card> getCards()
        {
            return cards;
        }

        public Card Play(int index)
        {
            Card tmp = cards[index];
            cards.Remove(tmp);
            return (tmp);
        }

        public void Show()
        {
            Card card;
            int i = 0;

            foreach (var it in cards)
            {
                card = it;
                i += 1;
                Console.WriteLine("[" + i + "] : " + card.value.ToString() + " " + card.color.ToString());
            }
        }

        public void TakeStack(List<Card> stack)
        {
            Card tmp;

            foreach (var it in stack)
            {
                tmp = it;
                cards.Add(tmp);
            }
            return;
        }
    }
}