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
        public String Name { get; }
        public Strategy Strategy { get; set; } 
        public Deck Deck { get; set; }
        public Player(String name)
        {
            Name = name;
            Strategy = new ZeroStrategy();
            Deck = new Deck();
        }
        public Player(String name, Strategy strategy)
        {
            Name = name;
            Strategy = strategy;
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
