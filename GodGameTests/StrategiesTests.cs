using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GodGameLibrary;
using GodGameLibrary.Strategies;

namespace GodGameTests
{
    [TestClass]
    public class StrategiesTests
    {
        [TestMethod]
        public void ZeroStrategyTest()
        {
            Strategy strategy = new ZeroStrategy();
            Deck deck = Deck.GetStandardDeck();
            Assert.AreEqual(strategy.GetNumber(deck), 0);
        }

        [TestMethod]
        public void FirstCardColorStrategyTest() 
        {
            Strategy strategy = new FirstCardColorStrategy();
            Card[] cards = new Card[18];
            cards[0] = new Card(Nominals.jack, Suits.spades, Colors.black);
            cards[1] = new Card(Nominals.queen, Suits.diamonds, Colors.red);

            Deck deck = new Deck(cards);
            Assert.AreEqual(strategy.GetNumber(deck), 0);

        }

    }
}
