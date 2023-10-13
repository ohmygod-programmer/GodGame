using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GodGameLibrary;

namespace Musk
{
    internal class CollisiumSandbox : ICollisiumSandbox
    {
        public bool Play(Player player1, Player player2)
        {
            int player1Number = player1.ChooseNumber();
            int player2Number = player2.ChooseNumber();
            if (player1.GetCardColor(player2Number) == player2.GetCardColor(player1Number))
            {
                return true;
            }
            return false;
        }
    }
}
