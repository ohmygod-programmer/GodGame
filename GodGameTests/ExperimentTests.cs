using GodGameLibrary;
using GodGameLibrary.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GodGameApp;
using System.Collections;

namespace GodGameTests
{
    [TestClass]
    public class ExperimentTests
    {
        [TestMethod]
        public void ExperimentTest()
        {
            Deck deck = Deck.GetStandardDeck();
            deck.RandomShuffle();

            Player elon = new Player("Musk");
            elon.Strategy = new ZeroStrategy();
            Player mark = new Player("Zukerberg");
            mark.Strategy = new ZeroStrategy();
            Player[] players = { elon, mark };
            CollisiumSandbox collisiumSandbox = new CollisiumSandbox(players);
            bool res = collisiumSandbox.Play(deck);
            if (deck.GetCard(0).Color == deck.GetCard(deck.Size() / 2).Color)
            {
                Assert.IsTrue(res);
            }
            else
            {
                Assert.IsFalse(res);
            }


        }
    }
}
