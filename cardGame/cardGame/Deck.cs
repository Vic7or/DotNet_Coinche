using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardGame
{
    class Deck
    {
        public Deck()
        {
            createDeck();
        }

        public List<Card>   cardList;

        public void createDeck()
        {
            cardList = new List<Card>();
            cardList.Add(new Card(Card.Color.CLUB, Card.Value.SEVEN));
            cardList.Add(new Card(Card.Color.CLUB, Card.Value.EIGHT));
            cardList.Add(new Card(Card.Color.CLUB, Card.Value.NINE));
            cardList.Add(new Card(Card.Color.CLUB, Card.Value.TEN));
            cardList.Add(new Card(Card.Color.CLUB, Card.Value.JACK));
            cardList.Add(new Card(Card.Color.CLUB, Card.Value.QUEEN));
            cardList.Add(new Card(Card.Color.CLUB, Card.Value.KING));
            cardList.Add(new Card(Card.Color.CLUB, Card.Value.ACE));
            cardList.Add(new Card(Card.Color.DIAMOND, Card.Value.SEVEN));
            cardList.Add(new Card(Card.Color.DIAMOND, Card.Value.EIGHT));
            cardList.Add(new Card(Card.Color.DIAMOND, Card.Value.NINE));
            cardList.Add(new Card(Card.Color.DIAMOND, Card.Value.TEN));
            cardList.Add(new Card(Card.Color.DIAMOND, Card.Value.JACK));
            cardList.Add(new Card(Card.Color.DIAMOND, Card.Value.QUEEN));
            cardList.Add(new Card(Card.Color.DIAMOND, Card.Value.KING));
            cardList.Add(new Card(Card.Color.DIAMOND, Card.Value.ACE));
            cardList.Add(new Card(Card.Color.HEART, Card.Value.SEVEN));
            cardList.Add(new Card(Card.Color.HEART, Card.Value.EIGHT));
            cardList.Add(new Card(Card.Color.HEART, Card.Value.NINE));
            cardList.Add(new Card(Card.Color.HEART, Card.Value.TEN));
            cardList.Add(new Card(Card.Color.HEART, Card.Value.JACK));
            cardList.Add(new Card(Card.Color.HEART, Card.Value.QUEEN));
            cardList.Add(new Card(Card.Color.HEART, Card.Value.KING));
            cardList.Add(new Card(Card.Color.HEART, Card.Value.ACE));
            cardList.Add(new Card(Card.Color.SPADE, Card.Value.SEVEN));
            cardList.Add(new Card(Card.Color.SPADE, Card.Value.EIGHT));
            cardList.Add(new Card(Card.Color.SPADE, Card.Value.NINE));
            cardList.Add(new Card(Card.Color.SPADE, Card.Value.TEN));
            cardList.Add(new Card(Card.Color.SPADE, Card.Value.JACK));
            cardList.Add(new Card(Card.Color.SPADE, Card.Value.QUEEN));
            cardList.Add(new Card(Card.Color.SPADE, Card.Value.KING));
            cardList.Add(new Card(Card.Color.SPADE, Card.Value.ACE));
            //SHUFFLE HERE
        }

        public void distrib(JClient[] clients)
        {
            List<Hand>      hands = new List<Hand>();
        
            while (hands.Count() < 4)
            {
                List<Card>  draw = new List<Card>();
                while (draw.Count() < 8)
                {

                    draw.Add(cardList.First());
                    cardList.RemoveAt(0);
                }
                hands.Add(new Hand(draw));
            }
            clients[0].hand = hands.get(0);
            clients[1].hand = hands.get(1);
            clients[2].hand = hands.get(2);
            clients[3].hand = hands.get(3);
            return;
        }

        public void reset()
        {
            createDeck();
        }
    }
}