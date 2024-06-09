using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{

    public class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }

        public Card(string suit, string value)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }

    public class CardDeck
    {
        private List<Card> cards;

        public CardDeck()
        {
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            cards = new List<Card>();
            string[] suits = { "Heart", "Square", "Cross", "Spade" };
            string[] values = { "A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2" };

            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    cards.Add(new Card(suit, value));
                }
            }
        }

        public void PrintDeck()
        {
            foreach (var card in cards)
            {
                Console.WriteLine(card);
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            int n = cards.Count;

            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                var value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            CardDeck deck = new CardDeck();

            Console.WriteLine("Initial Deck:");
            deck.PrintDeck();

            Console.WriteLine("\nShuffled Deck:");
            deck.Shuffle();
            deck.PrintDeck();
        }
    }
}