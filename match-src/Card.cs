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
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
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
