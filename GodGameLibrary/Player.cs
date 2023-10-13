using GodGameLibrary.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodGameLibrary
{
    public class Player
    {
        String Name;
        public Strategy Strategy { get; set; } 
        public Deck Deck { get; set; }
        public Player(String name)
        {
            this.Name = name;
            Strategy = new ZeroStrategy();
            Deck = new Deck();
        }
        public int ChooseNumber()
        {
            return Strategy.GetNumber(Deck);
        }
        public Colors GetCardColor(int number)
        {
            return Deck.GetCard(number).Color;
        }

    }
}
