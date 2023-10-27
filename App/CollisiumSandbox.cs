using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GodGameLibrary;

namespace GodGameApp
{
    internal class CollisiumSandbox
    {
        private readonly Player _player1;
        private readonly Player _player2;
        public CollisiumSandbox(IEnumerable<Player> players)
        {
            var playersList = players.ToList();
            _player1 = playersList[0];
            _player2 = playersList[1];
        }
        public bool Play(Deck deck)
        {
            _player1.Deck = deck.GetFirstNCardsDeck(deck.Size() / 2);
            _player2.Deck = deck.GetLastNCardsDeck(deck.Size() / 2);
            int player1Number = _player1.ChooseNumber();
            int player2Number = _player2.ChooseNumber();
            if (_player1.GetCardColor(player2Number) == _player2.GetCardColor(player1Number))
            {
                return true;
            }
            return false;
        }
    }
}
