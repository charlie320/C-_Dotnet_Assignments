using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    public class Card {
        public string stringVal;
        public string suit;
        public int val = 0;
    }

    public class Deck {
        public List<Card> cards = new List<Card>();
        public Dictionary<int, string> cardNames = new Dictionary<int, string>() {
         {1, "Ace"},
         {2, "Two"},
         {3, "Three"},
         {4, "Four"},
         {5, "Five"},
         {6, "Six"},
         {7, "Seven"},
         {8, "Eight"},
         {9, "Nine"},
         {10, "Ten"},
         {11, "Jack"},
         {12, "Queen"},
         {13, "King"}
        };

        public Deck() { // Constructor
            string s;
            for (int i = 0; i < 4; i++) {
                if (i == 0) {
                    s = "Clubs";
                } else if (i == 1) {
                    s = "Diamonds";
                } else if (i == 2) {
                    s = "Hearts";
                } else {
                    s = "Spades";
                }
                for (int j = 0; j < 13; j++) {
                    Card createdCard = new Card();
                    createdCard.suit = s;
                    createdCard.val = j+1;
                    createdCard.stringVal = this.cardNames[createdCard.val];
                    this.cards.Add(createdCard);
                }
            }
            // foreach (Card card in cards) {
            //     Console.WriteLine("{0} of {1}, val = {2}", card.stringVal, card.suit, card.val);
                // Console.WriteLine(card.stringVal);
                // Console.WriteLine(card.val);                
            // }            
            
        } // end of Deck constructor

        // Methods
        public void Shuffle() {
            Card tempCard;
            int randIdx;
            Random rand = new Random();
            for (int i = 0; i < cards.Count; i++) {
                randIdx = rand.Next(0,52);
                tempCard = this.cards[i];
                this.cards[i] = this.cards[randIdx];
                this.cards[randIdx] = tempCard;
            }
        }

        public Card Deal() {
            Card holdCard = this.cards[0];
            cards.RemoveAt(0);
            return holdCard;
        }

        public void Reset() {
            List<Card> tempDeck = new List<Card>();
            string s;
            for (int i = 0; i < 4; i++) {
                if (i == 0) {
                    s = "Clubs";
                } else if (i == 1) {
                    s = "Diamonds";
                } else if (i == 2) {
                    s = "Hearts";
                } else {
                    s = "Spades";
                }
                for (int j = 0; j < 13; j++) {
                    Card createdCard = new Card();
                    createdCard.suit = s;
                    createdCard.val = j+1;
                    createdCard.stringVal = this.cardNames[createdCard.val];           
                    tempDeck.Add(createdCard);
                }
                this.cards = tempDeck;
            }
        }

    } // end of Deck class

    public class Player {
        public string name;
        public List<Card> hand = new List<Card>();

        public Card Draw(Deck deck) {
            Card tempCard = deck.Deal();
            this.hand.Add(tempCard);
            return tempCard;
        }

        public Card Discard(List<Card> myHand, int idx) {
            if (myHand[idx] != null) {
                Card tempCard = myHand[idx];
                myHand.RemoveAt(idx);
                return tempCard;
            } else {
                return null;
            }
        }
    } // end of Player class

    class Program
    {
        static void Main(string[] args)
        {
            Deck myFirstDeck = new Deck();
            Player me = new Player();
            myFirstDeck.Shuffle();
            
            foreach (Card card in myFirstDeck.cards) {
                Console.WriteLine(card.stringVal + " of " + card.suit);
            }

            Card removed = myFirstDeck.Deal();
            Console.WriteLine("Top card is " + removed.stringVal + " " + removed.suit);

            removed = myFirstDeck.Deal();
            Console.WriteLine("Top card is " + removed.stringVal + " " + removed.suit);

            myFirstDeck.Reset();
            // foreach ( Card card in myFirstDeck.cards) {
            //     Console.WriteLine(card.stringVal + " of " + card.suit);
            // }
            for (int i = 0; i < 5; i++) {
                me.Draw(myFirstDeck);
            }

            // foreach (Card card in me.hand) {
            //     Console.WriteLine("{0} of {1}", card.stringVal, card.suit);
            // }

            me.Discard(me.hand, 1);

        }
    }
}
