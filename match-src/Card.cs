namespace match_src
{
    public class Card
    {
        public enum Suit 
        {
            Heart,
            Club,
            Diamond,
            Spade
        }

        public enum Value
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }

        public Value CardValue { get; }
        public Suit CardSuit { get; }

        public Card(Value value, Suit suit)
        {
            CardValue = value;
            CardSuit = suit;
        }

        public override string ToString()
        {
            return $"{CardSuit} - {CardValue}";
        }
    }
}
