using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GodGameLibrary;

namespace Musk
{
    internal class CollisiumSandbox
    {
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly Deck _deck;
        public CollisiumSandbox(IEnumerable<Player> players, Deck deck)
        {
            var playersList = players.ToList();
            _player1 = playersList[0];
            _player2 = playersList[1];
            _deck = deck;
        }
        public bool Play()
        {
            _deck.RandomShuffle();
            _player1.Deck = _deck.GetFirstNCardsDeck(_deck.Size() / 2);
            _player2.Deck = _deck.GetLastNCardsDeck(_deck.Size() / 2);
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
