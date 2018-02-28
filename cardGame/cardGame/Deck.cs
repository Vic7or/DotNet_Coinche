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
            CreateDeck();
        }

        public List<Card> CardList { get; set; }

        public void CreateDeck()
        {
            CardList = new List<Card>();
            CardList.Add(new Card(Card.Color.CLUB, Card.Value.SEVEN));
            CardList.Add(new Card(Card.Color.CLUB, Card.Value.EIGHT));
            CardList.Add(new Card(Card.Color.CLUB, Card.Value.NINE));
            CardList.Add(new Card(Card.Color.CLUB, Card.Value.TEN));
            CardList.Add(new Card(Card.Color.CLUB, Card.Value.JACK));
            CardList.Add(new Card(Card.Color.CLUB, Card.Value.QUEEN));
            CardList.Add(new Card(Card.Color.CLUB, Card.Value.KING));
            CardList.Add(new Card(Card.Color.CLUB, Card.Value.ACE));
            CardList.Add(new Card(Card.Color.DIAMOND, Card.Value.SEVEN));
            CardList.Add(new Card(Card.Color.DIAMOND, Card.Value.EIGHT));
            CardList.Add(new Card(Card.Color.DIAMOND, Card.Value.NINE));
            CardList.Add(new Card(Card.Color.DIAMOND, Card.Value.TEN));
            CardList.Add(new Card(Card.Color.DIAMOND, Card.Value.JACK));
            CardList.Add(new Card(Card.Color.DIAMOND, Card.Value.QUEEN));
            CardList.Add(new Card(Card.Color.DIAMOND, Card.Value.KING));
            CardList.Add(new Card(Card.Color.DIAMOND, Card.Value.ACE));
            CardList.Add(new Card(Card.Color.HEART, Card.Value.SEVEN));
            CardList.Add(new Card(Card.Color.HEART, Card.Value.EIGHT));
            CardList.Add(new Card(Card.Color.HEART, Card.Value.NINE));
            CardList.Add(new Card(Card.Color.HEART, Card.Value.TEN));
            CardList.Add(new Card(Card.Color.HEART, Card.Value.JACK));
            CardList.Add(new Card(Card.Color.HEART, Card.Value.QUEEN));
            CardList.Add(new Card(Card.Color.HEART, Card.Value.KING));
            CardList.Add(new Card(Card.Color.HEART, Card.Value.ACE));
            CardList.Add(new Card(Card.Color.SPADE, Card.Value.SEVEN));
            CardList.Add(new Card(Card.Color.SPADE, Card.Value.EIGHT));
            CardList.Add(new Card(Card.Color.SPADE, Card.Value.NINE));
            CardList.Add(new Card(Card.Color.SPADE, Card.Value.TEN));
            CardList.Add(new Card(Card.Color.SPADE, Card.Value.JACK));
            CardList.Add(new Card(Card.Color.SPADE, Card.Value.QUEEN));
            CardList.Add(new Card(Card.Color.SPADE, Card.Value.KING));
            CardList.Add(new Card(Card.Color.SPADE, Card.Value.ACE));
            //SHUFFLE HERE
            CardList = ShuffleList(CardList);
        }

        public void Distrib(List<Player> players)
        {
            List<Hand> hands = new List<Hand>();

            while (hands.Count() < 4)
            {
                List<Card> draw = new List<Card>();
                while (draw.Count() < 8)
                {
                    draw.Add(CardList.First());
                    CardList.RemoveAt(0);
                }
                hands.Add(new Hand(draw));
            }
            players[0].Hand = hands[0];
            players[1].Hand = hands[1];
            players[2].Hand = hands[2];
            players[3].Hand = hands[3];
            return;
        }

        public void Reset()
        {
            CreateDeck();
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