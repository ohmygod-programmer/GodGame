using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodGameLibrary.Strategies
{
    public class FirstCardColorStrategy : Strategy
    {
        public override int GetNumber(Deck deck)
        {
            Card card = deck.GetCard(0);
            if (card.Color == Colors.red)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
