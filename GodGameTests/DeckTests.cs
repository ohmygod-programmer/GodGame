using Microsoft.VisualStudio.TestTools.UnitTesting;
using GodGameLibrary;
namespace GodGameTests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void ColorsTest()
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
            deck.RandomShuffle();
            red_c = 0;
            black_c = 0;
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
    }
}
