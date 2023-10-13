using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodGameLibrary
{
    public abstract class Strategy
    {
        public static bool CompareColors(Card[] cards, Colors[] colors)
        {
            if (cards.Length < colors.Length)
            {
                return false;
            }
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].Color != colors[i])
                {
                    return false;
                }
            }
            return true;
        }
        public abstract int GetNumber(Deck deck);
        
    }
}
