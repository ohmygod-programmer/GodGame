using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GodGameLibrary;
namespace Musk
{
    internal interface ICollisiumSandbox
    {
        public bool Play(Player player1, Player player2);
    }
}
