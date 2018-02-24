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

        public List<Card> cardList { get; set; }

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
            cardList = ShuffleList(cardList);
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
            clients[0].hand = hands[0];
            clients[1].hand = hands[1];
            clients[2].hand = hands[2];
            clients[3].hand = hands[3];
            return;
        }

        public void reset()
        {
            createDeck();
        }

        private List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }
    }
}