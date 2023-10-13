using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodGameLibrary.Strategies
{

    public class ZeroStrategy : Strategy
    {
        public override int GetNumber(Deck deck)
        {
            return 0;
        }
    }
}
