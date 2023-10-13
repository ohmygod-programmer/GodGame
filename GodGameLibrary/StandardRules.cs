namespace GodGameLibrary
{
    public enum Nominals : int
    {
        six,
        seven,
        eight,
        nine,
        ten,
        jack,
        queen,
        king,
        ace
    }
    public enum Suits : int
    {
        clubs,
        diamonds,
        hearts,
        spades
    }
    public enum Colors : int
    {
        red,
        black
    }

    public class Card
    {
        public Nominals Nominal { get; }
        public Suits Suit { get; }
        public Colors Color { get; }
        public Card(Nominals nominal, Suits suit, Colors color)
        {
            this.Nominal = nominal;
            this.Suit = suit;
            this.Color = color;
        }

    }
    public class StandardGenerator
    {
        private static HashSet<Card> StandardDeck;
        static StandardGenerator()
        {
            StandardDeck = new HashSet<Card>();
            foreach (Nominals n in (Nominals[])Enum.GetValues(typeof(Nominals)))
            {
                foreach (Suits s in (Suits[])Enum.GetValues(typeof(Suits)))
                {
                    Colors color;
                    if (s == Suits.clubs || s == Suits.spades)
                    {
                        color = Colors.black;
                    }
                    else
                    {
                        color = Colors.red;
                    }
                    StandardDeck.Add(new Card(n, s, color));
                }
            }
        }
        public static Card[] getStartSequence()
        {
            return StandardDeck.ToArray();
        }
    }

}
