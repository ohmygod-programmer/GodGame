using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodGameLibrary
{
    public class Deck
    {
        private Card[] Сards;
        public static Deck GetStandardDeck()
        {
            return new Deck(StandardGenerator.getStartSequence());
        }
        public Deck() {
            Сards = Array.Empty<Card>();
        }
        public Deck(Card[] cards)
        {
            this.Сards = new Card[cards.Length];
            Array.Copy(cards, this.Сards, cards.Length);
        }
        public Deck(Deck deck) :  this(deck.Сards)
        {
        }
        public int Size()
        {
            return Сards.Length;
        }
        public Card GetCard(int index)
        {
            return Сards[index];
        }
        public Deck GetFirstNCardsDeck(int n)
        {
            if (Сards.Length >= n)
            {
                Card[] newCards = new Card[n];
                Array.Copy(Сards, newCards, n);
                Deck newDeck = new(newCards);
                return newDeck;
            }
            else throw new Exception("Deck is too small");
        }
        public Deck GetLastNCardsDeck(int n)
        {
            if (Сards.Length >= n)
            {
                Card[] newCards = new Card[n];
                Array.Copy(Сards, Сards.Length - n, newCards, 0, n);
                Deck newDeck = new(newCards);
                return newDeck;
            }
            else throw new Exception("Deck is too small");
        }
        public void RandomShuffle()
        {
            // Shuffle the deck to randomize its cards
            Random rng = new();
            int n = Сards.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (Сards[n], Сards[k]) = (Сards[k], Сards[n]);
            }
        }
    }
}
