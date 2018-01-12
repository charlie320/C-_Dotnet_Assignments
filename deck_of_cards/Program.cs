using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    public class Card {
        string stringVal;
        string suit;
        int val = 0;
    }

    public class Deck {
        List<Card> cards = new List<Card>();

        public Deck() {
            for (int i = 0; i < 4; i++) {
                // Left off here 1/12/18 @ 12:54;
            }
        }
    }

    public class Player {
        string name;
        List<Card> hand = new List<Card>();
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
