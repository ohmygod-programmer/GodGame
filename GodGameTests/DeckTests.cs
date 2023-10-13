using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GodGameLibrary;
namespace GodGameTests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void ColorsInStandardDeckTest()
        {
            Deck deck = Deck.GetStandardDeck();
            int size = deck.Size();
            Assert.AreEqual(36, size);
            int red_c = 0;
            int black_c = 0;
            for (int i = 0; i < size; i++)
            {
                if (deck.GetCard(i).Color == Colors.black)
                {
                    black_c++;
                }
                else if (deck.GetCard(i).Color == Colors.red)
                {
                    red_c++;
                }
            }
            Assert.AreEqual(18, red_c);
            Assert.AreEqual(18, black_c);
        }
        [TestMethod]
        public void ColorsInShuffledDeckTest()
        {
            Deck deck = Deck.GetStandardDeck();
            int size = deck.Size();
            deck.RandomShuffle();
            int red_c = 0;
            int black_c = 0;
            for (int i = 0; i < size; i++)
            {
                if (deck.GetCard(i).Color == Colors.black)
                {
                    black_c++;
                }
                else if (deck.GetCard(i).Color == Colors.red)
                {
                    red_c++;
                }
            }
            Assert.AreEqual(18, red_c);
            Assert.AreEqual(18, black_c);
        }
        [TestMethod]
        public void ColorsInSlicedDeckTest()
        {
            Deck deck = Deck.GetStandardDeck();
            int size = deck.Size();
            deck.RandomShuffle();
            Deck deck1 = deck.GetFirstNCardsDeck(size / 2);
            Deck deck2 = deck.GetLastNCardsDeck(size / 2);
            int red_c = 0;
            int black_c = 0;
            for (int i = 0; i < size/2; i++)
            {
                if (deck1.GetCard(i).Color == Colors.black)
                {
                    black_c++;
                }
                else if (deck1.GetCard(i).Color == Colors.red)
                {
                    red_c++;
                }
                if (deck2.GetCard(i).Color == Colors.black)
                {
                    black_c++;
                }
                else if (deck2.GetCard(i).Color == Colors.red)
                {
                    red_c++;
                }
            }
            Assert.AreEqual(18, red_c);
            Assert.AreEqual(18, black_c);

        }
    }
}
